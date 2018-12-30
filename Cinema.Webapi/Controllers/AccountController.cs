using System;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Commands.Users;
using Cinema.Infrastrucure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Webapi.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private IUserService _userService;
        // ticket

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            System.Console.WriteLine("guwno");
            return Json(await _userService.GetAccountAsync(UserId));
        }

        //GetTicket

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] Register command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(),
                command.Email, command.Username,command.Password,command.Role);

            return Created("/account",null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
            => Json(await _userService.LoginAsync(command.Username, command.Password));
    }
}