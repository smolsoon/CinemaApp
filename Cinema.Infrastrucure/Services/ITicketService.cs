using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;

namespace Cinema.Infrastrucure.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDetailsDTO>> GetForUserAsync(Guid userId);
        Task<TicketDTO> GetAsync(Guid userId, Guid movieId, Guid ticketId);
        Task PurchaseAsync(Guid userId, Guid movieId, int amount);
        Task CancelAsync(Guid userId, Guid movieId, int amount);
    }
}