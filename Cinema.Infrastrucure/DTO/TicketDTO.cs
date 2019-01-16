using System;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.DTO
{
    public class TicketDTO
    {
        public string Id { get; set;}
        public string MovieId { get; set; }
        public int Seating { get; set; }
        public decimal Price { get; set; }
    }
}