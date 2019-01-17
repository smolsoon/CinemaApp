using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.DTO
{
    public class MovieDetailsDTO 
    {
        public Guid _id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string Type { get; set; } 
        public string Director { get; set; } 
        public string Producer { get; set; } 
        public DateTime DateTime { get; set;}
        public int TicketsCount { get; set; }
        public int PurchasedTicketsCount { get; set; }
        public int AvailableTicketsCount { get; set; }
        public IEnumerable<TicketDetailsDTO> Tickets { get; set;}
    }
}