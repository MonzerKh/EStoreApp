using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        private readonly AppDbContext appContext;

        public InvoiceController(AppDbContext appContext)
        {
            this.appContext = appContext;
        }


        [HttpGet]
        public IActionResult GetInvoice()
        {
            var item = this.appContext.Invoices.ToList();
            return Ok(item);
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
        public IActionResult GetInvoiceTotal(int InvoiceId)
        {
            var result = this.appContext
                .InvoiceDetails.Where(r => r.InvoiceId == InvoiceId)
                .Sum(r => r.ProductPrice - r.Discount);

            return Ok(result);
        }
    }
}
