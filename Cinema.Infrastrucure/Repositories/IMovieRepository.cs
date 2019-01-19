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
        // Task <IEnumerable<Ticket>> GetTicketsAsync(Guid id);
        // Task <IEnumerable<Ticket>> AddTicketAsync(Ticket ticket);
        // Task <IEnumerable<Ticket>> UpdateTicketAync(Ticket ticket);
        // Task <IEnumerable<Ticket>> DeleteTicketAsync(Ticket ticket);

    }
}