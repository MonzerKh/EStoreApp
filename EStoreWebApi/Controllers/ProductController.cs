using AutoMapper;
using EStoreWebApi.AppCore.DomainDto.InvoiceDetail;
using EStoreWebApi.AppCore.DomainDto.Product;
using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public IActionResult UpdateProduct(ProductUpDto Prod)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.appContext.Invoices.Find(Prod.Id);

            if (item == null)
            {
                return NotFound($"The Id Requested Is Not Exists : {Prod.Id}");
            }

            this.mapper.Map(Prod, item);

            this.appContext.Invoices.Update(item);

            var IsUpdate = this.appContext.SaveChanges() > 0;

            return Ok(IsUpdate);
        }

        [HttpGet]
        public IActionResult GetInvoiceProduct([FromQuery] ProductFilter? filter)
        {
            var query = this.appContext.Products.AsQueryable();

            if (filter?.ProductName != null)
            {
                query = query.Where(r => r.ProductName == filter.ProductName);
            }

            if (filter?.ProductionCountry != null)
            {
                query = query.Where(r => r.ProductionCountry == filter.ProductionCountry);
            }

            if (filter?.BarcodeCode != null)
            {
                query = query.Where(r => r.BarcodeCode == filter.BarcodeCode);
            }

            if (filter?.Brand != null)
            {
                query = query.Where(r => r.Brand == filter.Brand);
            }

            if (filter?.Counter != null)
            {
                query = query.Where(r => r.Counter >= filter.Counter);
            }

            var qstring = query.ToQueryString();

            var result = query.ToList();

            return Ok(result);
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
