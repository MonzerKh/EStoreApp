using EStoreWebApi.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EStoreWebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BaseController : Controller
{
    protected readonly AppDbContext appContext;

    public BaseController(AppDbContext appContext)
    {
        this.appContext = appContext;
    }
}
