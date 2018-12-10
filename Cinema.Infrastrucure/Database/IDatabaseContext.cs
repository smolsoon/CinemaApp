using Cinema.Infrastrucure.DTO;
using Cinema.Model.Domain;
using MongoDB.Driver;

namespace Cinema.Infrastrucure.Database
{
    public interface IDatabaseContext
    {
         IMongoCollection<MovieDTO> Movies { get; }
         //IMongoCollection<MovieDTO> Users { get; }
    }
}