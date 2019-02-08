using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.Infrastrucure.Database;
using Cinema.Infrastrucure.DTO;
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
        private readonly MovieContext _movieContext = null;
        public MovieRepository(IOptions<DatabaseSettings> settings)
        {
            _movieContext = new MovieContext(settings);
        }

        public async Task<Movie> GetAsync(Guid id)
        {
            var filter = Builders<Movie>.Filter.Eq("_id", id);
            return await _movieContext.Movies.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Movie>> BrowseAsync()
        {
            return await _movieContext.Movies.Find(_ => true).ToListAsync();
        }
        public async Task AddAsync(Movie movie)
            => await _movieContext.Movies.InsertOneAsync(movie);
        
        public async Task UpdateAsync(Movie movie)
            => await _movieContext.Movies.ReplaceOneAsync(x => x._id == movie._id, movie);
        
        public async Task DeleteAsync(Movie movie)
            => await _movieContext.Movies.DeleteOneAsync(x => x._id == movie._id);

    
    }
}