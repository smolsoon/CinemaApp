using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinema.Model.Domain
{
    public class Movie : Entity
    {
        [BsonId]
        public ObjectId Id { get; set;}
        public string Title { get; protected set; } // tytul
        public string Description { get; protected set; } // opis
        public string Type { get; protected set; } // gatunek
        public string Director { get; protected set; } // rezyser
        public string Producer { get; protected set; } // producent
        public DateTime Time { get; protected set;} // czas filmu
        public ICollection<Photo> Photos { get;set; } //  
        private ISet<Ticket> _tickets = new HashSet<Ticket>();
        public IEnumerable<Ticket> Tickets => _tickets;
        public IEnumerable<Ticket> PurchasedTickets => Tickets.Where(x => x.Purchased);
        public IEnumerable<Ticket> AvailableTickets => Tickets.Except(PurchasedTickets);

        protected Movie(){}

        public Movie(Guid id, string title, string description, DateTime time)
        {
            Idd = id;   
            Title = title;
            Description = description;
            Time = DateTime.UtcNow;
        }

        public void AddTickets(int amount, decimal price)
        {
            var seating = _tickets.Count + 1;
            for(var i=0; i<amount; i++)
            {
                _tickets.Add(new Ticket(this, seating, price));
                seating++;
            }
        }
    }
}