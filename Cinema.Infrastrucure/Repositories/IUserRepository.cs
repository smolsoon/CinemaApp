using System;
using System.Threading.Tasks;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id); 
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}