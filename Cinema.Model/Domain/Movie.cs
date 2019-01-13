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
        public string Title { get; protected set; } 
        public string Description { get; protected set; } 
        public string Type { get; protected set; } 
        public string Director { get; protected set; } 
        public string Producer { get; protected set; }
        public DateTime DateTime { get; protected set; }
        private ISet<Ticket> _tickets { get; set; }
        public IEnumerable<Ticket> Tickets => _tickets;
        public IEnumerable<Ticket> PurchasedTickets => Tickets.Where(x => x.Purchased);
        public IEnumerable<Ticket> AvailableTickets => Tickets.Except(PurchasedTickets);
        
        public Movie(Guid id, string title, string description, string type, string director, string producer, DateTime dateTime)
        {
            Idd = id;
            Title = title;
            Description = description;
            Type = type;
            Director = director;
            Producer = producer;
            DateTime = dateTime;
        }

        public void AddTickets(int amount, decimal price)
        {
            _tickets = new HashSet<Ticket>();
            var seating = _tickets.Count + 1;
            for(var i=0; i<amount; i++)
            {
                _tickets.Add(new Ticket(this, seating, price));
                seating++;
            }
        }

        public void PurchaseTickets(User user, int amount)
        {
            if(AvailableTickets.Count() < amount)
            {
                throw new Exception($"Not enough available tickets to purchase ({amount}) by user: '{user.Username}'.");
            }
            var tickets = AvailableTickets.Take(amount);
            foreach(var ticket in tickets)
            {
                ticket.Purchase(user);
            }
        }

        public void CancelPurchasedTickets(User user, int amount)
        {
            var tickets = GetTicketsPurchasedByUser(user);
            if(tickets.Count() < amount)
            {
                throw new Exception($"Not enough purchased tickets to be canceled ({amount}) by user: '{user.Username}'.");
            }
            foreach(var ticket in tickets.Take(amount))
            {
                ticket.Cancel();
            }
        }

        public IEnumerable<Ticket> GetTicketsPurchasedByUser(User user)
            => PurchasedTickets.Where(x => x.UserId == user.Idd);
        
      }
}