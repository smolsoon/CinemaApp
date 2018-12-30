using System;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Webapi.Controllers
{
    [Route("[controller]")]
    //[Produces("application/json")]
    public class ApiControllerBase : Controller
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) : 
            Guid.Empty;
    }
}