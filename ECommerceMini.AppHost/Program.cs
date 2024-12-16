var builder = DistributedApplication.CreateBuilder(args);

var productApi = builder.AddProject<Projects.ECommerceMini_ProductService>("apiservice-product");
var orderApi = builder.AddProject<Projects.ECommerceMini_OrderService>("apiservice-order");

builder.AddProject<Projects.ECommerceMini_Web>("webfrontend")
    .WithReference(productApi)
    .WithReference(orderApi);

builder.Build().Run();
