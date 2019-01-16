using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Commands.Movies;
using Cinema.Infrastrucure.DTO;
using Cinema.Infrastrucure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson;


namespace Cinema.Webapi.Controllers
{
    [Route("[controller]")]
    public class MoviesController : ApiControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMemoryCache _cache;
        public MoviesController(IMovieService movieService, IMemoryCache cache)
        {
            _movieService = movieService;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movies = await _movieService.BrowseAsync();
            return Json(movies);
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> Get(ObjectId movieId)
        {
            var movie = await _movieService.GetAsync(movieId);
            if(movie == null)
                return NotFound();
            return Json(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateMovie command)
        {
            command.MovieId = ObjectId.GenerateNewId();
            await _movieService.CreateAsync(command.MovieId, command.Title, command.Description, command.Type, command.Director, command.Producer, command.DateTime);
            await _movieService.AddTicketsAsync(command.MovieId, command.Tickets, command.Price);
            return Created($"/movies/{command.MovieId}", null);
        }

        [HttpPut("{movieId}")]
        [Authorize]
        public async Task<IActionResult> Put(ObjectId movieId, [FromBody]UpdateMovie command)
        {
            await _movieService.UpdateAsync(movieId, command.Title,command.Description);
            return NoContent();
        }

        [HttpDelete("{movieId}")]
        [Authorize]
        public async Task<IActionResult> Delete(ObjectId movieId)
        {
            await _movieService.DeleteAsync(movieId);
            return NoContent();
        }

    }
}