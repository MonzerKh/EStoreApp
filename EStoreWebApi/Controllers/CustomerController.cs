using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers;

public class CustomerController : BaseController
{
    public CustomerController(AppDbContext appContext) : base(appContext)
    {
      
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
