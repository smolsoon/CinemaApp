using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using Cinema.Infrastrucure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Webapi.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : ApiControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // [HttpGet]
        // public async Task<IActionResult> Get(string name)
        // {
        //     var movie = _movieService.BrowseAsync<IEnumerable<MovieDTO>>("events");
        //     if(movie == null)
        //     {
        //         movie = await _movieService.BrowseAsync(name);
        //     }

        //     return Json(movie);
        // }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> Get(Guid movieId)
        {
            var movie = await _movieService.GetAsync(movieId);
            if(movie == null)
            {
                return NotFound();
            }

            return Json(movie);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string title)
        {
            var movie = await _movieService.BrowseAsync(title);

            return Ok(movie);
        }

    }
}