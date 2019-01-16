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
        private List<Ticket> _tickets { get; set; }
        [BsonId]
        public string _id { get; protected set; }
        public string Title { get; protected set; } 
        public string Description { get; protected set; } 
        public string Type { get; protected set; } 
        public string Director { get; protected set; } 
        public string Producer { get; protected set; }
        public DateTime DateTime { get; protected set; }
        public IEnumerable<Ticket> Tickets => _tickets;
        public IEnumerable<Ticket> PurchasedTickets => Tickets.Where(x => x.Purchased);
        public IEnumerable<Ticket> AvailableTickets => Tickets.Except(PurchasedTickets);
        
        public Movie(string id, string title, string description, string type, string director, string producer, DateTime dateTime)
        {
            _id = id;
            Title = title;
            Description = description;
            Type = type;
            Director = director;
            Producer = producer;
            DateTime = dateTime;
        }

        public void AddTickets(int amount, decimal price)
        {
            _tickets = new List<Ticket>();
            var seating = _tickets.Count + 1;
            for(var i=0; i<amount; i++)
            {
                var id = ObjectId.GenerateNewId().ToString();
                _tickets.Add(new Ticket(this, id, seating, price));
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
            => PurchasedTickets.Where(x => x.UserId == user._id);
        
      }
}