using AutoMapper;
using EStoreWebApi.AppCore.DomainDto.InvoiceDetail;
using EStoreWebApi.AppCore.DomainDto.Product;
using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IMapper mapper;
        public ProductController(AppDbContext appContext, IMapper mapper) : base(appContext)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult InsertProduct(ProductInsDto cust)
        {

            var item = mapper.Map<Product>(cust);

            this.appContext.Products.Add(item);

            this.appContext.SaveChanges();

            return Ok(item.Id);
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
