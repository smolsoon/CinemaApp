using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Database;
using Cinema.Model.Domain;
using Cinema.Model.Repositories;
using MongoDB.Driver;

namespace Cinema.Infrastrucure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDatabaseContext _database;
        public MovieRepository(IDatabaseContext database)
        {
            _database = database;
        }
        public async Task<IEnumerable<Movie>> GetMovies()
            => await _database.Movies.Find(_=>true).ToListAsync();
        
        public async Task<Movie> Get(string title)
        {
            FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq(m=>m.Title,title);
            return await _database.Movies.Find(filter).FirstOrDefaultAsync();
        }
        public async Task Create(Movie movie)
        {
            await _database.Movies.InsertOneAsync(movie);
        }

        public async Task<bool> Update(Movie movie)
        {
            ReplaceOneResult update = await _database.Movies
                .ReplaceOneAsync(filter: g => g.GuidId == movie.GuidId, replacement:movie);

            return update.IsAcknowledged && update.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string title)
        {
            FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq(m => m.Title, title);
            DeleteResult delete = await _database.Movies.DeleteOneAsync(title);

            return delete.IsAcknowledged && delete.DeletedCount > 0;
        }
    }
}