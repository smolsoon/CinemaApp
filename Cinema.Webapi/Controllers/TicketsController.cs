using System;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson;

namespace Cinema.Webapi.Controllers
{
    [Authorize]
    [Route("movies/{movieId}/tickets")]
    public class TicketsController : ApiControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // [HttpGet("{ticketId}")]
        // public async Task<IActionResult> Get(Guid movieId, Guid ticketId)
        // {
        //     var ticket = await _ticketService.GetAsync(UserId, movieId, ticketId);
        //     if(ticket == null)
        //         return NotFound();
        //     return Json(ticket);
        // }

        // [HttpPost("purchase/{amount}")]
        // public async Task<IActionResult> Post(Guid movieId, int amount)
        // {
        //     await _ticketService.PurchaseAsync(UserId, movieId, amount);
        //     return NoContent();
        // }

        // [HttpDelete("cancel/{amount}")]
        // public async Task<IActionResult> Delete(Guid movieId, int amount)
        // {
        //     await _ticketService.CancelAsync(UserId, movieId, amount);
        //     return NoContent();
        //}
    }
}