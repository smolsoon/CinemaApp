using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Services
{
    public interface IMovieService
    {
        Task<MovieDetailsDTO> GetAsync(string id);
        Task<IEnumerable<MovieDTO>> BrowseAsync();
        Task CreateAsync(string id, string title, string description, string type, string director, string producer, DateTime dateTime);
        Task AddTicketsAsync(string movieId, int amount, decimal price);
        Task UpdateAsync(string id, string title, string description);  
        Task DeleteAsync(string id);
    }
}