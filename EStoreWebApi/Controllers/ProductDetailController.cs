using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{

    public class ProductDetailController : BaseController
    {
        public ProductDetailController(AppDbContext appContext):base(appContext) { }


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
