using AutoMapper;
using EStoreWebApi.AppCore.DomainDto;
using EStoreWebApi.AppCore.DomainDto.InvoiceDetail;
using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EStoreWebApi.Controllers
{

    public class InvoiceDetailsController : BaseController
    {
        private readonly IMapper mapper;
        public InvoiceDetailsController(AppDbContext appContext, IMapper mapper) : base(appContext)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult InsertInvoiceDetails(InvoiceDetailInsDto cust)
        {

            var item = mapper.Map<InvoiceDetail>(cust);

            this.appContext.InvoiceDetails.Add(item);

            this.appContext.SaveChanges();

            return Ok(item.Id);
        }

        [HttpPost]
        public IActionResult UpdateInvoiceDetails(InvoiceDetailUpDto invDetls)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.appContext.Invoices.Find(invDetls.Id);

            if (item == null)
            {
                return NotFound($"The Id Requested Is Not Exists : {invDetls.Id}");
            }

            //var IsCustomerExists = this.appContext.Customers.Find(invDetls.CustomerId);

            //if (IsCustomerExists == null)
            //{
            //    return NotFound($"The Customer Id Requested Is Not Exists : {invDetls.CustomerId}");
            //}

            this.mapper.Map(invDetls, item);

            this.appContext.Invoices.Update(item);

            var IsUpdate = this.appContext.SaveChanges() > 0;

            return Ok(IsUpdate);
        }

        [HttpGet]
        public IActionResult GetInvoiceDetail([FromQuery] InvoiceDetailFilter? filter)
        {
            var query = this.appContext.InvoiceDetails.AsQueryable();

            if (filter?.ProductId != null)
            {
                query = query.Where(r => r.ProductId == filter.ProductId);
            }

            if (filter?.ProductPrice != null)
            {
                query = query.Where(r => r.ProductPrice == filter.ProductPrice);
            }

            if (filter?.Discount != null)
            {
                query = query.Where(r => r.Discount == filter.Discount);
            }

            if (filter?.amount != null)
            {
                query = query.Where(r => r.amount >= filter.amount);
            }

            var qstring = query.ToQueryString();

            var result = query.ToList();

            return Ok(result);
        }


        //[HttpGet]
        //public IActionResult GetInvoiceDetails()
        //{
        //    var items = this.appContext.InvoiceDetails.ToList();
        //    return Ok(items);
        //}

        //[HttpGet]
        //public IActionResult GetIvoiceDetailByInvoiceId(int InvoiceId)
        //{
        //    var item = this.appContext
        //        .InvoiceDetails
        //        .Where(r => r.InvoiceId == InvoiceId)
        //        .ToList();
        //    return Ok(item);
        //}
    }
}
