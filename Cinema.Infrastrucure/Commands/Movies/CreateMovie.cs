using System;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Commands.Movies
{
    public class CreateMovie
    {
        public ObjectId MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public int Tickets { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}