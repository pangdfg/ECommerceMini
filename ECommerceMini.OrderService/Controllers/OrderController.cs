using Confluent.Kafka;
using ECommerce.Services.OrderService.Kafka;
using ECommerceMini.Model;
using ECommerceMini.OrderService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ECommerceMini.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(OrderDbContext Dbcontext, IKafkaProducer producer ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<OrderModel>>> GetOrder()
        {
            return await Dbcontext.Orders.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<OrderModel>> PostOrder(OrderModel order)
        {
            order.OrderDate = DateTime.Now;
            Dbcontext.Orders.Add(order);
            await Dbcontext.SaveChangesAsync();

            var orderMessage = new OrderMessage
            {
                OrderId = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity
            };

            await producer.ProduceAsync("order-topic", new Message<string, string>
            {
                Key = order.Id.ToString(),
                Value = JsonSerializer.Serialize(orderMessage)
            });

            return order;
        }
    }
}
