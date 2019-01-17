using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Services
{
    public interface IUserService
    {
        Task<AccountDTO> GetAccountAsync(Guid userId);
        Task RegisterAsync(Guid userId, string email,
            string username, string password, string role = "user");

        Task<TokenDTO> LoginAsync(string email, string password);
    }
}