using ECommerceMini.Model;
using ECommerceMini.ProductService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMini.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ProductDbContext DbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetProducts()
        {
            return await DbContext.Products.ToListAsync();
        }
    }
}
