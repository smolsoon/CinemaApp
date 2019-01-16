using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Database;
using Cinema.Infrastrucure.Settings;
using Cinema.Model.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Cinema.Infrastrucure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _database = null;
        public MovieRepository(IOptions<DatabaseSettings> settings)
        {
            _database = new MovieContext(settings);
        }

        public async Task<Movie> GetAsync(ObjectId id)
            => await _database.Movies.AsQueryable().FirstOrDefaultAsync(x => x._id == id);

        public async Task<IEnumerable<Movie>> BrowseAsync()
        {
            var movies = _database.Movies.AsQueryable();
            return await Task.FromResult(movies);
        }      

        public async Task AddAsync(Movie movie)
            => await _database.Movies.InsertOneAsync(movie);
        
        public async Task UpdateAsync(Movie movie)
            => await _database.Movies.ReplaceOneAsync(x => x._id == movie._id, movie);
        
        public async Task DeleteAsync(Movie movie)
            => await _database.Movies.DeleteOneAsync(x => x._id == movie._id);
    }
}