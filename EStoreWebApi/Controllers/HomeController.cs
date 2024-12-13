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
                .SingleOrDefault();
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


        public IActionResult GetInvoice()
        {
            var item = this.appContext.Invoices.ToList();
            return Ok(item);
        }

        [HttpGet]
        public IActionResult GetInvoiceDetails()
        {
            var items = this.appContext.InvoiceDetails.ToList();
            return Ok(items);
        }


        [HttpGet]
        public IActionResult GetInvoceById(int InvoiceId)
        {
            var item = this.appContext
                .Invoices
                .Where(r => r.Id == InvoiceId)
                .SingleOrDefault();
            return Ok(item);
        }

        [HttpGet]
        public IActionResult GetIvoiceDetailByInvoiceId(int InvoiceId)
        {
            var item = this.appContext
                .InvoiceDetails
                .Where(r => r.InvoiceId == InvoiceId)
                .ToList();
            return Ok(item);
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var item = this.appContext.Customers.ToList();
            return Ok(item);
        }

        public IActionResult GetCustomerId(int CustomerId)
        {
            var item = this.appContext
                .Customers
                .Where(r => r.Id == CustomerId)
                .SingleOrDefault();
            return Ok(item);
        }

        public IActionResult GetInvoiceTotal(int InvoiceId)
        {
            var item = this.appContext
                    .InvoiceDetails.Sum(invoice => invoice.ProductPrice)
                    .where(r => r.InvoiceId == InvoiceId);
                    

            //.Where(r => r.Id == CustomerId)
            //.SingleOrDefault();
            return Ok(item);
        }

    }
}

