using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDTO>> GetForUserAsync(Guid userId);
        Task<TicketDetailsDTO> GetAsync(Guid userId, Guid movieId, Guid ticketId);
        Task PurchaseAsync(Guid userId, Guid movieId, int amount);
        Task CancelAsync(Guid userId, Guid movieId, int amount);
        //Task <IEnumerable<TicketDTO>> GetTicket();
    }
}