using Confluent.Kafka;
using ECommerceMini.Model;
using ECommerceMini.ProductService.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECommerceMini.ProductService.Kafka
{
    public class KafkaConsumer(IServiceScopeFactory scopeFactory) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            return Task.Run(() =>
            {
                _ = ConsumeAsync("order-topic", stoppingToken);
            }, stoppingToken);
        }

        public async Task ConsumeAsync(string topic, CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = "order-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            using var consumer = new ConsumerBuilder<string, string>(config).Build();

            consumer.Subscribe(topic);
            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(stoppingToken);

                var order = JsonConvert.DeserializeObject<OrderMessage>(consumeResult.Message.Value);
                using var scope = scopeFactory.CreateScope();
                var DbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();

                var product = await DbContext.Products.FindAsync(order.ProductId);
                if (product != null)
                {
                    product.Quantity -= order.Quantity;
                    await DbContext.SaveChangesAsync();
                }
            }
            consumer.Close();
        }
    }
}