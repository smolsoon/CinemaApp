using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Model.Domain;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id); 
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task <IEnumerable<Ticket>> GetTickets();
        Task<Ticket> PurchaseTickets(Ticket ticket);
        Task<Ticket> CancelTickets (Ticket ticket);

    }
}