using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{

    public class InvoiceController : BaseController
    {
        public InvoiceController(AppDbContext appContext) :base(appContext) { }
       
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
