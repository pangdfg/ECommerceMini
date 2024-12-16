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
    public class OrderController(OrderDbContext Dbcontext ) : ControllerBase
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

            return order;
        }
    }
}
