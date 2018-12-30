using System;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;

namespace Cinema.Infrastrucure.Services
{
    public interface IUserService
    {
        Task<AccountDTO> GetAccountAsync(Guid userId);
        Task RegisterAsync(Guid userId, string email,
            string username, string password, string role = "user");

        Task<TokenDTO> LoginAsync(string username, string password);
    }
}