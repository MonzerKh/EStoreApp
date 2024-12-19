using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext appContext;

        public ProductController(AppDbContext appContext)
        {
            this.appContext = appContext;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            var item = this.appContext.Products.ToList();
            return Ok(item);
        }

        [HttpGet]
        public IActionResult GetProductById(int Id)
        {
            var item = this.appContext
                .Products
                .Where(r => r.Id == Id)
                .SingleOrDefault();
            return Ok(item);
        }
    }
}
