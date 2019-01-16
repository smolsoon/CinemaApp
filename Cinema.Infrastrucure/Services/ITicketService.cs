using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDetailsDTO>> GetForUserAsync(ObjectId userId);
        Task<TicketDTO> GetAsync(ObjectId userId, ObjectId movieId, ObjectId ticketId);
        Task PurchaseAsync(ObjectId userId, ObjectId movieId, int amount);
        Task CancelAsync(ObjectId userId, ObjectId movieId, int amount);
    }
}