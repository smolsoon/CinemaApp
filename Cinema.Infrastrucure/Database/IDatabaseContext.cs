using Cinema.Model.Domain;
using MongoDB.Driver;

namespace Cinema.Infrastrucure.Database
{
    public interface IDatabaseContext
    {
         IMongoCollection<Movie> Movies { get; }
    }
}