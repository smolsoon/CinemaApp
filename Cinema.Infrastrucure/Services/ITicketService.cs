using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDTO>> GetForUserAsync(ObjectId userId);
        Task<TicketDetailsDTO> GetAsync(ObjectId userId, string movieId, string ticketId);
        Task PurchaseAsync(ObjectId userId, string movieId, int amount);
        Task CancelAsync(ObjectId userId, string movieId, int amount);
    }
}