using System;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Services
{
    public interface IUserService
    {
        Task<AccountDTO> GetAccountAsync(ObjectId userId);
        Task RegisterAsync(ObjectId userId, string email,
            string username, string password, string role = "user");

        Task<TokenDTO> LoginAsync(string email, string password);
    }
}