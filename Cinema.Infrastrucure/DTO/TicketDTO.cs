using System;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.DTO
{
    public class TicketDTO
    {
        public Guid Id { get; set;}
        public Guid MovieId { get; set; }
        public int Seating { get; set; }
        public decimal Price { get; set; }
    }
}