using System;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Database;
using Cinema.Model.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;

namespace Cinema.Infrastrucure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseContext _database;
        public UserRepository(IDatabaseContext database)
        {
            _database = database;
        }
        
        public async Task<User> GetAsync(Guid id)
            => await _database.Users.AsQueryable().FirstOrDefaultAsync(x => x.Idd == id);

        public async Task<User> GetAsync(string email)
            => await _database.Users.AsQueryable().FirstOrDefaultAsync(x => x.Email == email);

        public async Task AddAsync(User user)
            => await _database.Users.InsertOneAsync(user);

        public async Task DeleteAsync(User user)
            => await _database.Users.DeleteOneAsync(x => x.Idd == user.Idd);

        public async Task UpdateAsync(User user)
            => await _database.Users.ReplaceOneAsync(x => x.Idd == user.Idd, user);
    }
}