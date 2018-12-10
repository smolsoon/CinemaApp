using System;
using System.Threading.Tasks;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.Repositories
{
    public interface IUserRepository
    {
         Task<User> GetUserById(Guid id);
         Task<User> GetUserByEmail(string email);
         Task CreateUser(User user);
         Task UpdateUser(User user);
         Task DeleteUser(User user);
    }
}