using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Cinema.Webapi.Controllers
{
    [Route("[controller]")]
    public class ApiControllerBase : Controller
    {
        protected ObjectId UserId => User?.Identity?.IsAuthenticated == true ?
            ObjectId.Parse(User.Identity.Name) : 
            ObjectId.Empty;
    }
}