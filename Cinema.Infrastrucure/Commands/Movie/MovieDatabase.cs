using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinema.Infrastrucure.Commands.Movie
{
    public class MovieDatabase
    {
        [BsonId]
        public ObjectId Id {get; set;}
        public string Title { get; set; } // tytul
        public string Description { get; set; } // opis
        public string Type { get; set; } // gatunek
        public string Director { get; set; } // rezyser
        public string Producer { get; set; } // producent
    }
}