using System;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.Repositories
{
    public interface IUserRepository
    {
         Task<UserDTO> GetUserById(Guid id);
         Task RegisterUser(User user);
         Task UpdateUser(User user);
         Task DeleteUser(User user);
    }
}