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

    public BaseController()
    {

    }

    //public (bool Status, ApiResponse<T>) ValidateModelState<T>()
    //{
    //    if (!ModelState.IsValid)
    //        return (false, new ApiResponse<T>()
    //        {
    //            Status = StatusEnum.ModelStateInvalid,
    //            Data = default(T),
    //            Message = AppConfiguration.GetStateErrorMessage(ModelState)
    //        });
    //    return (true, null);

    //}
}
