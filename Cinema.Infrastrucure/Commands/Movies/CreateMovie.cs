using System;

namespace Cinema.Infrastrucure.Commands.Movies
{
    public class CreateMovie
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; } // tytul
        public string Description { get; set; } // opis
        public string Type { get; set; } // gatunek
        public string Director { get; set; } // rezyser
        public string Producer { get; set; } // producent
        public DateTime Time { get; set; } // czas filmu
        public int Tickets { get; set; } // bilety
        public decimal Price { get; set; }// Cena
    }
}