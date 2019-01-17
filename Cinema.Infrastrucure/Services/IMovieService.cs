using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Services
{
    public interface IMovieService
    {
        Task<MovieDetailsDTO> GetAsync(Guid id);
        Task<IEnumerable<MovieDTO>> BrowseAsync();
        Task CreateAsync(Guid id, string title, string description, string type, string director, string producer, DateTime dateTime);
        Task AddTicketsAsync(Guid movieId, int amount, decimal price);
        Task UpdateAsync(Guid id, string title, string description);  
        Task DeleteAsync(Guid id);
    }
}