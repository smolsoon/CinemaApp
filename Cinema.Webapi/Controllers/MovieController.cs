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
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Get(string title)
        {
            var movies = _cache.Get<IEnumerable<MovieDTO>>("movies");
            if(movies == null)
            {
                Console.WriteLine("Fetching from service.");
                movies = await _movieService.BrowseAsync(title);
                _cache.Set("movies", movies, TimeSpan.FromMinutes(1));
            }
            else
            {
                Console.WriteLine("Fetching from cache.");
            }

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
            command.MovieId = Guid.NewGuid();
            await _movieService.CreateAsync(command.MovieId, command.Title, command.Description, command.Type, command.Director, command.Producer, command.DateTime);
            await _movieService.AddTicketsAsync(command.MovieId, command.Tickets, command.Price);
            return Created($"/movies/{command.MovieId}", null);
        }

        [HttpPut("{movieId}")]
        [Authorize(Policy = "HasAdminRole")]
        public async Task<IActionResult> Put(Guid movieId, [FromBody]UpdateMovie command)
        {
            await _movieService.UpdateAsync(movieId, command.Title,command.Description);
            return NoContent();
        }

        [HttpDelete("{movieId}")]
        [Authorize(Policy = "HasAdminRole")]
        public async Task<IActionResult> Delete(Guid movieId)
        {
            await _movieService.DeleteAsync(movieId);
            return NoContent();
        }

    }
}