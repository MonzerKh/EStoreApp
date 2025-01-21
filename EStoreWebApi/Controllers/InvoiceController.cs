using AutoMapper;
using AutoMapper.QueryableExtensions;
using EStoreWebApi.AppCore.DomainDto;
using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure;
using EStoreWebApi.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EStoreWebApi.Controllers
{

    public class InvoiceController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRep;

        public InvoiceController(
            AppDbContext appContext, 
            IMapper mapper,
            ICustomerRepository customerRep) : base(appContext)
        {
            this.mapper = mapper;
            this.customerRep = customerRep;
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

        [HttpPost]
        public IActionResult DeleteInvoice(int Id)
        {
            var item = this.appContext.Invoices.Find(Id);

            if (item == null)
            {
                return NotFound("No Invoice Found");
            }

            this.appContext.Invoices.Remove(item);

            var status = this.appContext.SaveChanges() > 0;

            return Ok(status);
        }



        ////[HttpGet]
        ////public IActionResult GetInvoice()
        ////{
        ////    var item = this.appContext.Invoices.ToList();
        ////    return Ok(item);
        ////}

        //[HttpGet]
        //public IActionResult GetInvoceById(int InvoiceId)
        //{
        //    var item = this.appContext
        //        .Invoices
        //        .Where(r => r.Id == InvoiceId)
        //        .SingleOrDefault();
        //    return Ok(item);
        //}

        [HttpGet]
        public IActionResult GetInvoice([FromQuery]InvoiceFilter? filter)
        {
            var query = this.appContext.Invoices
                .ProjectTo<InvoiceReadDto>(mapper.ConfigurationProvider)
                .AsQueryable();

            if (filter?.CustomerName != null)
            {
                query = query.Where(r => r.CustomerName!.Contains( filter.CustomerName));
            }

            if (filter?.CustomerId != null)
            {
                query = query.Where(r => r.CustomerId == filter.CustomerId);
            }

            if (filter?.InvoiceNote != null)
            {
                query = query.Where(r => r.InvoiceNote == filter.InvoiceNote);
            }

            if (filter?.InvoiceTotalMax != null)
            {
                query = query.Where(r => r.InvoiceTotal <= filter.InvoiceTotalMax);
            }

            if (filter?.InvoiceTotalMin != null)
            {
                query = query.Where(r => r.InvoiceTotal >= filter.InvoiceTotalMin);
            }

            if (filter?.InvoiceId !=null)
            {
                query = query.Where(r => r.Id == filter.InvoiceId);
            }

            var qstring = query.ToQueryString();

            var result = query.ToList();


            return Ok(result);

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
