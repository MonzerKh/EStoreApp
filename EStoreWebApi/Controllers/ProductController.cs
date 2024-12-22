using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{

    public class ProductController : BaseController
    {
        public ProductController(AppDbContext appContext):base(appContext) { }


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
