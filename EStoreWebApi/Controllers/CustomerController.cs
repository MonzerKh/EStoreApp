using AutoMapper;
using EStoreWebApi.AppCore.DomainDto;
using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure;
using EStoreWebApi.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EStoreWebApi.Controllers;

public class CustomerController : BaseController
{
    private readonly ICustomerRepository customerRep;

    public CustomerController(ICustomerRepository customerRep)
    {
        this.customerRep = customerRep;
    }

    [HttpPost]
    public IActionResult InsertCustomer(CustomerInsDto cust)
    {
        return Ok(customerRep.Insert(cust));
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

            var result = customerRep.Update(cust);

            if (result == null)
            {
                return NotFound($"The Id Requested Is Not Exists : {cust.Id}");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

    [HttpGet]
    public IActionResult GetCustomer([FromQuery] CustomerFilter? filter)
    {
        return Ok(customerRep.Get(filter));
    }


    [HttpPost]
    public IActionResult DeleteCustomer(int Id)
    {
        var result = customerRep.Delete(Id);
       
        if (result == null)
            return NotFound($"The Id Requested Is Not Exists : {Id}");

        return Ok(result);

    }




}
