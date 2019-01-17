using Cinema.Infrastrucure.Settings;
using Cinema.Model.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cinema.Infrastrucure.Database
{
    public class TicketContext
    {
        private readonly IMongoDatabase _database = null;
        public TicketContext(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Ticket> Tickets
        {
            get
            {
                return _database.GetCollection<Ticket>("Tickets");
            }
        }
    }
}