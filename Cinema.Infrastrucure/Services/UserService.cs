using System;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.Infrastrucure.DTO;
using Cinema.Infrastrucure.Repositories;
using Cinema.Infrastrucure.Settings;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public async Task<AccountDTO> GetAccountAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            return _mapper.Map<AccountDTO>(user);
        }

        public async Task<TokenDTO> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user == null)
            {
                throw new Exception("Invalid credentials.");
            }
            if(user.Password != password)
            {
                throw new Exception("Invalid credentials.");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);

            return new TokenDTO
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.Role
            };
        }

        public async Task RegisterAsync(Guid userId, string email, string name, string password, string role = "user")
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }
            user = new User(userId, role, name, email, password);
            await _userRepository.AddAsync(user);
        }
    }
}