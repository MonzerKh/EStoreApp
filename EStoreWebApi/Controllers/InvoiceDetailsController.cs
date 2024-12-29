using AutoMapper;
using EStoreWebApi.AppCore.DomainDto.InvoiceDetail;
using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{

    public class InvoiceDetailsController : BaseController
    {
        private readonly IMapper mapper;
        public InvoiceDetailsController(AppDbContext appContext, IMapper mapper) : base(appContext)
        {
            this.mapper = mapper;
        }

        public IActionResult InsertInvoiceDetails(InvoiceDetailInsDto cust)
        {

            var item = mapper.Map<InvoiceDetail>(cust);

            this.appContext.InvoiceDetails.Add(item);

            this.appContext.SaveChanges();

            return Ok(item.Id);
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
