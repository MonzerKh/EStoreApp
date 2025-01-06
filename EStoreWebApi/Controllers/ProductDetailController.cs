using AutoMapper;
using EStoreWebApi.AppCore.DomainDto.Product;
using EStoreWebApi.AppCore.DomainDto.ProductDetail;
using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{

    public class ProductDetailController : BaseController
    {

        private readonly IMapper mapper;
        public ProductDetailController(AppDbContext appContext, IMapper mapper) : base(appContext)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult InsertProductDetail(ProductDetailInsDto cust)
        {

            var item = mapper.Map<ProductDetail>(cust);

            this.appContext.ProductDetails.Add(item);

            this.appContext.SaveChanges();

            return Ok(item.Id);
        }

        [HttpPost]
        public IActionResult UpdateProductDetl(ProductDetailUpDto ProdDetl)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.appContext.Invoices.Find(ProdDetl.Id);

            if (item == null)
            {
                return NotFound($"The Id Requested Is Not Exists : {ProdDetl.Id}");
            }

            this.mapper.Map(ProdDetl, item);

            this.appContext.Invoices.Update(item);

            var IsUpdate = this.appContext.SaveChanges() > 0;

            return Ok(IsUpdate);
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
