using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinema.Model.Domain
{
    public class Movie : Entity
    {
        [BsonId]
        public ObjectId Id {get; protected set;}
        public string Title { get; protected set; } // tytul
        public string Description { get; protected set; } // opis
        public string Type { get; protected set; } // gatunek
        public string Director { get; protected set; } // rezyser
        public string Producer { get; protected set; } // producent

        protected Movie(){}

        public Movie(Guid id, string title, string description, string type, string director, string producer)
        {
            GuidId = id;
            Title = title;
            Description = description;
            Type = type;
            Director = director;
            Producer = producer;
        }
    }
    
}