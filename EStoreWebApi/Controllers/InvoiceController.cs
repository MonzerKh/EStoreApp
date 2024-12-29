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


        public IActionResult InsertInvoice(InvoiceInsDto cust)
        {

            var item = mapper.Map<Invoice>(cust);

            this.appContext.Invoices.Add(item);

            this.appContext.SaveChanges();

            return Ok(item.Id);
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
