using AutoMapper;
using EStoreWebApi.AppCore.DomainDto;
using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers;

public class CustomerController : BaseController
{
    private readonly IMapper mapper;

    public CustomerController(
        AppDbContext appContext,
        IMapper mapper) : base(appContext)
    {
        this.mapper = mapper;
    }

    [HttpPost]
    public IActionResult InsertCustomer(InvoiceInsDto cust)
    {
        //var item = new Customer()
        //{
        //    CustomerName = cust.CustomerName,
        //    CustomerSorName = cust.CustomerSorName,
        //    BirthDate = cust.BirthDate,
        //    PhonNumber = cust.PhonNumber,
        //    Email = cust.Email,
        //    ProductPrice = cust.ProductPrice
        //};

        var item = mapper.Map<Customer>(cust);

        this.appContext.Customers.Add(item);

        this.appContext.SaveChanges();

        return Ok(item.Id);
    }

    [HttpPost]
    public IActionResult UpdateCustomer([FromBody] CustomerUpdDto cust)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.appContext.Customers.Find(cust.Id);

            if (item == null)
            {
                return NotFound($"The Id Requested Is Not Exists : {cust.Id}");
            }


            this.mapper.Map(cust,item);

           
            //item.CustomerName = cust.CustomerName;
            //item.CustomerSorName = cust.CustomerSorName;
            //item.BirthDate = cust.BirthDate;
            //item.PhonNumber = cust.PhonNumber;
            //item.Email = cust.Email;
            //item.ProductPrice = cust.ProductPrice;


            this.appContext.Customers.Update(item);

            this.appContext.SaveChanges();

            return Ok(true);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

    [HttpPost]
    public IActionResult DeleteCustomer(int Id)
    {
        var item = this.appContext.Customers.Find(Id);

        if (item == null)
        {
            return NotFound($"The Id Requested Is Not Exists : {Id}");
        }

        this.appContext.Customers.Remove(item);

        this.appContext.SaveChanges();

        return Ok(true);

    }



    [HttpGet]
    public IActionResult GetCustomer()
    {
        var item = this.appContext.Customers.ToList();
        return Ok(item);
    }

    [HttpGet]
    public IActionResult GetCustomerId(int CustomerId)
    {
        var item = this.appContext
            .Customers
            .Where(r => r.Id == CustomerId)
            .SingleOrDefault();
        return Ok(item);
    }
}
