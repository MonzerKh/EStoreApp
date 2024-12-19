using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        public CustomerController(AppDbContext appContext)
        {
            AppContext = appContext;
        }

        public AppDbContext AppContext { get; }


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
}
