using AutoMapper;
using EStoreWebApi.AppCore.DomainDto;
using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{

    public class InvoiceController : BaseController
    {
        private readonly IMapper mapper;
        public InvoiceController(AppDbContext appContext,IMapper mapper) :base(appContext)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult InsertInvoice(InvoiceInsDto inv)
        {

            var item = mapper.Map<Invoice>(inv);

            this.appContext.Invoices.Add(item);

            this.appContext.SaveChanges();

            return Ok(item.Id);
        }

        [HttpPost]
        public IActionResult UpdateInvoice(InvoiceUpDto inv)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.appContext.Invoices.Find(inv.Id);

            if (item == null)
            {
                return NotFound($"The Id Requested Is Not Exists : {inv.Id}");
            }

            var IsCustomerExists = this.appContext.Customers.Find(inv.CustomerId);

            if (IsCustomerExists == null)
            {
                return NotFound($"The Customer Id Requested Is Not Exists : {inv.CustomerId}");
            }

            this.mapper.Map(inv, item);

            this.appContext.Invoices.Update(item);

            var IsUpdate = this.appContext.SaveChanges() > 0;

            return Ok(IsUpdate);
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
