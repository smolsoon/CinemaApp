using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;

namespace Cinema.Infrastrucure.Services
{
    public interface IMovieService
    {
        Task<MovieDetailsDTO> GetAsync(Guid id);
        Task<MovieDetailsDTO> GetAsync(string title);
        Task<IEnumerable<MovieDTO>> BrowseAsync(string title = null);
        Task CreateAsync(Guid id, string title, string description,
            DateTime time);
        Task AddTicketsAsync(Guid movieId, int amount, decimal price);
        Task UpdateAsync(Guid id, string title, string description);  
       Task DeleteAsync(Guid id);
    }
}