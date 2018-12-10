using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.Infrastrucure.Database;
using Cinema.Infrastrucure.DTO;
using Cinema.Model.Domain;
using MongoDB.Driver;

namespace Cinema.Infrastrucure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDatabaseContext _database;
        private readonly IMapper _mapper;
        public MovieRepository(IDatabaseContext database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MovieDTO>> GetMovies()
        {
            var movie =  await _database.Movies.Find(_=>true).ToListAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movie);
        }

        public async Task<MovieDTO> Get(string title)
        {
            FilterDefinition<MovieDTO> filter = Builders<MovieDTO>.Filter.Eq(m=>m.Title,title);
            return await _database.Movies.Find(filter).FirstOrDefaultAsync();
        }
        public async Task Create(MovieDTO movie)
        {
            await _database.Movies.InsertOneAsync(movie);
        }

        public async Task<bool> Update(MovieDTO movie)
        {
            ReplaceOneResult update = await _database.Movies
                .ReplaceOneAsync(filter: g => g.GuidId == movie.GuidId, replacement:movie);

            return update.IsAcknowledged && update.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string title)
        {
            FilterDefinition<MovieDTO> filter = Builders<MovieDTO>.Filter.Eq(m => m.Title, title);
            DeleteResult delete = await _database.Movies.DeleteOneAsync(title);

            return delete.IsAcknowledged && delete.DeletedCount > 0;
        }
    }
}