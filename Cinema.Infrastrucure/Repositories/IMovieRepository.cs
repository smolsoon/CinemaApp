using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using Cinema.Model.Domain;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> GetAsync(Guid id); 
        Task<IEnumerable<Movie>> BrowseAsync();
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(Movie movie);

    }
}