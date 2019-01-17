using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Commands.Movies;
using Cinema.Infrastrucure.DTO;
using Cinema.Infrastrucure.Services;
using Cinema.Model.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson;


namespace Cinema.Webapi.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
            =>  Json(await _movieService.BrowseAsync());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(Guid id)
        {
           return Json(await _movieService.GetAsync(id));
        }
        

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateMovie command)
        {
            command.MovieId = Guid.NewGuid();
            await _movieService.CreateAsync(command.MovieId, command.Title, command.Description, command.Type, command.Director, command.Producer, command.DateTime);
            await _movieService.AddTicketsAsync(command.MovieId, command.Tickets, command.Price);
            return Created($"/movies/{command.MovieId}", null);
        }

        [HttpPut("{movieId}")]
        [Authorize]
        public async Task<IActionResult> Put(Guid movieId, [FromBody]UpdateMovie command)
        {
            await _movieService.UpdateAsync(movieId, command.Title,command.Description);
            return NoContent();
        }

        [HttpDelete("{movieId}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid movieId)
        {
            await _movieService.DeleteAsync(movieId);
            return NoContent();
        }

    }
}