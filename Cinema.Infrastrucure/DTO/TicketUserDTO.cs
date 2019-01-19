using System;

namespace Cinema.Infrastrucure.DTO
{
    public class TicketUserDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } 
        public int Seating { get; set; }
        public decimal Price { get; set; }
        public string Username { get; set; } 
    }
}