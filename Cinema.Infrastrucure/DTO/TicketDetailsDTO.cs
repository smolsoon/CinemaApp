using System;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.DTO
{
    public class TicketDetailsDTO
    {
        public ObjectId MovieId { get; set; }
        public string MovieTitle{ get; set; }
    }
}