using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Database;
using Cinema.Model.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Cinema.Infrastrucure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDatabaseContext _database;
        public MovieRepository(IDatabaseContext database)
        {
            _database = database;
        }

        public async Task<Movie> GetAsync(Guid id)
            => await _database.Movies.AsQueryable().FirstOrDefaultAsync(x => x.Idd == id);

        public async Task<Movie> GetAsync(string title)
            => await _database.Movies.AsQueryable().FirstOrDefaultAsync(x => x.Title.ToLowerInvariant() == title.ToLowerInvariant());
        
        public async Task<IEnumerable<Movie>> BrowseAsync(string title = "")
        {
            var movies = _database.Movies.AsQueryable();
            if(!string.IsNullOrWhiteSpace(title))
            {
                movies = movies.Where(x => x.Title.ToLowerInvariant().Contains(title.ToLowerInvariant()));
            }

            return await Task.FromResult(movies);
        }      

        public async Task AddAsync(Movie movie)
            => await _database.Movies.InsertOneAsync(movie);
        
        public async Task UpdateAsync(Movie movie)
            => await _database.Movies.ReplaceOneAsync(x => x.Idd == movie.Idd, movie);
        
        public async Task DeleteAsync(Movie movie)
            => await _database.Users.DeleteOneAsync(x => x.Idd == movie.Idd);
    }
}