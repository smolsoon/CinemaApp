using System;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.DTO
{
    public class TicketMovieDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Seating { get; set; }
        public decimal Price { get; set; }
        public bool Available {get; set;} 

    }
}