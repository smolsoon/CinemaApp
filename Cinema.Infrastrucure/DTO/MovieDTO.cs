using System;

namespace Cinema.Infrastrucure.DTO
{
    public class MovieDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string Type { get; set; } 
        public string Director { get; set; } 
        public string Producer { get; set; } 
        public DateTime Time { get; set;}
        public int TicketsCount { get; set; }
        public int PurchasedTicketsCount { get; set; }
        public int AvailableTicketsCount { get; set; }
    
    }
}