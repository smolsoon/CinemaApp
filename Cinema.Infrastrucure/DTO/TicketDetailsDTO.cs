using System;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.DTO
{
    public class TicketDetailsDTO
    {
        public string Id { get; set;} 
        public string MovieId { get; set; }
        public int Seating { get; set; }
        public decimal Price { get; set; }
        public ObjectId? UserId { get; set; }
        public string Username { get; set; }
        public DateTime? PurchasedAt { get; set; }
        public bool Purchased { get; set; }
    }
}