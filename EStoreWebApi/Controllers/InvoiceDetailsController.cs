using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceDetailsController : Controller
    {
        private readonly AppDbContext appContext;

        public InvoiceDetailsController(AppDbContext appContext)
        {
            this.appContext = appContext;
        }

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
