using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        public  AppDbContext appContext { get; set; }

        public HomeController(AppDbContext appContext)
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
        public IActionResult GetProductDetails() 
        {
            var items = this.appContext.ProductDetails.ToList(); 
            return Ok(items);
        }

        [HttpGet]
        public IActionResult GetProductById(int Id)
        {
            var item = this.appContext
                .Products
                .Where(r=>r.Id == Id)
                .ToList();
            return Ok(item);
        }

        [HttpGet]
        public IActionResult GetProductDetailByProductId(int ProductId)
        {
            var item = this.appContext
                .ProductDetails
                .Where(r=>r.ProductId == ProductId)
                .ToList();
            return Ok(item);
        }
    }
}
