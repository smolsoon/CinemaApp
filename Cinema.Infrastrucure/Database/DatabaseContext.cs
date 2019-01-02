using Cinema.Infrastrucure.DTO;
using Cinema.Infrastrucure.Settings;
using Cinema.Model.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cinema.Infrastrucure.Database
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly IMongoDatabase _database = null;

        public DatabaseContext(IOptions<DatabaseSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            if(client != null)
                _database = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Movie> Movies => _database.GetCollection<Movie>("Movies");

        public IMongoCollection<User> Users =>  _database.GetCollection<User>("Users");

    }
}