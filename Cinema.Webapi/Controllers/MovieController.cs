using System;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using Cinema.Infrastrucure.Repositories;
using Cinema.Model.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _repository;
        public MovieController(IMovieRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] //GET: api/movie/
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _repository.GetMovies());
        }

        [HttpGet("{title}", Name = "Get")] //GET: api/movie/title
        public async Task<IActionResult> Get(string title)
        {
            var movie = await _repository.Get(title);
            if(movie == null)
            {
                return new NotFoundResult();
            }
            return new ObjectResult(movie);
        }

        [HttpPost] //POST: api/movie
        public async Task<IActionResult> Post([FromBody]MovieDTO movie)
        {
            movie.GuidId = Guid.NewGuid();
            await _repository.Create(movie);
            return new ObjectResult(movie);
        }

        [HttpPut("title")] //PUT: api/movie/title
        public async Task<IActionResult> Put(string title, [FromBody]MovieDTO movie)
        {
            var movieFromDatabase = await _repository.Get(title);
            if(movieFromDatabase == null)
            {
                return new NotFoundResult();
            }
            movie.GuidId = movieFromDatabase.GuidId;
            await _repository.Update(movie);
            return new ObjectResult(movie);
        }

        [HttpDelete("{title}")] //DELETE: api/movie/title
        public async Task<IActionResult> Delete(string title)
        {
            var movieFromDatabase = await _repository.Get(title);
            if(movieFromDatabase == null)
            {
                return new NotFoundResult();
            }
            await _repository.Delete(title);
            return new OkResult();
        }
    }
}