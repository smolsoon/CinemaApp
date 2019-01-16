using System;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Commands.Movies
{
    public class UpdateMovie
    {
        public ObjectId MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}