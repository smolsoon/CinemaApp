using System;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RegisterUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        Task<UserDTO> IUserRepository.GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}