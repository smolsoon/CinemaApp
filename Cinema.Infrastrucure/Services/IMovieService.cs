using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Services
{
    public interface IMovieService
    {
        Task<MovieDetailsDTO> GetAsync(ObjectId id);
        Task<IEnumerable<MovieDTO>> BrowseAsync();
        Task CreateAsync(ObjectId id, string title, string description, string type, string director, string producer, DateTime dateTime);
        Task AddTicketsAsync(ObjectId movieId, int amount, decimal price);
        Task UpdateAsync(ObjectId id, string title, string description);  
        Task DeleteAsync(ObjectId id);
    }
}