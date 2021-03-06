using System;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Commands.Users;
using Cinema.Infrastrucure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Cinema.Webapi.Controllers {
    [Route ("[controller]")]
    public class AccountController : ApiControllerBase {
        private readonly IUserService _userService;
        private readonly ITicketService _ticketService;

        public AccountController (IUserService userService, ITicketService ticketService) {
            _userService = userService;
            _ticketService = ticketService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get () => Json (await _userService.GetAccountAsync (UserId));

        // [HttpGet("tickets")]
        // [Authorize]
        // public async Task<IActionResult> GetTickets()
        //     => Json(await _ticketService.GetForUserAsync(UserId));

        [HttpPost ("register")]
        public async Task<IActionResult> Post ([FromBody] Register command) {
            await _userService.RegisterAsync (Guid.NewGuid (), command.Email, command.Username, command.Password, command.Role);
            return Created ("/account", null);
        }

        [HttpPost ("login")]
        public async Task<IActionResult> Post ([FromBody] Login command) => Json (await _userService.LoginAsync (command.Email, command.Password));
    
    }
}