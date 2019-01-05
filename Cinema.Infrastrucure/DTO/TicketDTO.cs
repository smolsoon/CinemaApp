using System;

namespace Cinema.Infrastrucure.DTO
{
    public class TicketDTO
    {
        public Guid MovieId { get; set; }
        public int Seating { get; set; }
        public decimal Price { get; set; }
        public Guid? UserId { get; set; }
        public string Username { get; set; }
        public DateTime? PurchasedAt { get; set; }
        public bool Purchased { get; set; }
    }
}