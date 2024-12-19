using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        public  AppDbContext appContext { get; set; }

        public HomeController(AppDbContext appContext)
        {
            this.appContext = appContext;
        }

    }
}

