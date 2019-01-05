using System;

namespace Cinema.Infrastrucure.DTO
{
    public class TicketDetailsDTO
    {
        public Guid MovieId { get; set; }
        public string MovieTitle{ get; set; }
    }
}