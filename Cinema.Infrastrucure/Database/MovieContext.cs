using Cinema.Infrastrucure.Settings;
using Cinema.Model.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cinema.Infrastrucure.Database
{
    public class MovieContext
    {
        private readonly IMongoDatabase _database = null;
        public MovieContext(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Movie> Movies
        {
            get
            {
                return _database.GetCollection<Movie>("Movies");
            }
        }
    }
}