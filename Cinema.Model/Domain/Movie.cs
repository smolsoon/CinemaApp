using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinema.Model.Domain
{
    public class Movie
    {
        private ISet<Ticket> _tickets = new HashSet<Ticket>();
        
        [BsonId]
        public Guid Id {get;set;}
        public string Title { get; protected set; } // tytul
        public string Description { get; protected set; } // opis
        public string Type { get; protected set; } // gatunek
        public string Director { get; protected set; } // rezyser
        public string Producer { get; protected set; } // producent
        public DateTime Time { get; protected set;} // czas filmu
        public ICollection<Photo> Photos { get;set; } //  
        public IEnumerable<Ticket> Tickets => _tickets;
        public IEnumerable<Ticket> PurchasedTickets => Tickets.Where(x => x.Purchased);
        public IEnumerable<Ticket> AvailableTickets => Tickets.Except(PurchasedTickets);

        protected Movie(){}

        public Movie(string title, string description, string type, string director, string producer)
        {
            Id = Guid.NewGuid();   
            Title = title;
            Description = description;
            Type = type;
            Director = director;
            Producer = producer;
            Photos = new Collection<Photo>();
        }
        
        public Movie(string username)
        {
            
        }
    }
    
}