using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext appContext;

        public ProductDetailController(AppDbContext appContext)
        {
            this.appContext = appContext;
        }


        [HttpGet]
        public IActionResult GetProductDetails()
        {
            var items = this.appContext.ProductDetails.ToList();
            return Ok(items);
        }



        [HttpGet]
        public IActionResult GetProductDetailByProductId(int ProductId)
        {
            var item = this.appContext
                .ProductDetails
                .Where(r => r.ProductId == ProductId)
                .ToList();
            return Ok(item);
        }


    }
}
