using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{

    public class InvoiceDetailsController : BaseController
    {
        public InvoiceDetailsController(AppDbContext appContext) : base(appContext) { }

        [HttpGet]
        public IActionResult GetInvoiceDetails()
        {
            var items = this.appContext.InvoiceDetails.ToList();
            return Ok(items);
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
    }
}
