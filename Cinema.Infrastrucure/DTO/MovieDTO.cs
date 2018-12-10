using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinema.Infrastrucure.DTO
{
    public class MovieDTO
    {
        [BsonId]
        public ObjectId Id {get;set;}
        public Guid GuidId {get;set;}
        public string Title {get;set;} // tytul
        public string Description {get;set;} // opis
        public string Type {get;set;} // gatunek
        public string Director {get;set;} // rezyser
        public string Producer {get;set;} // producent
        public string PhotoUrl { get; set; }
        public int TicketsCount { get; set; }
        public int PurchasedTicketsCount { get; set; }
        public int AvailableTicketsCount { get; set; }
    }
}