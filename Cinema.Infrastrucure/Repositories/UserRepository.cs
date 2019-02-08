using System;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Database;
using Cinema.Model.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Cinema.Infrastrucure.Settings;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthContext  _database = null;
        public UserRepository(IOptions<DatabaseSettings> settings)
        {
            _database = new AuthContext(settings);
        }
        
        public async Task<User> GetAsync(Guid id)
            => await _database.Users.AsQueryable().FirstOrDefaultAsync(x => x._id == id);

        public async Task<User> GetAsync(string email)
            => await _database.Users.AsQueryable().FirstOrDefaultAsync(x => x.Email == email);

        public async Task AddAsync(User user)
            => await _database.Users.InsertOneAsync(user);

        public async Task DeleteAsync(User user)
            => await _database.Users.DeleteOneAsync(x => x._id == user._id);

        public async Task UpdateAsync(User user)
            => await _database.Users.ReplaceOneAsync(x => x._id == user._id, user);

    }
}