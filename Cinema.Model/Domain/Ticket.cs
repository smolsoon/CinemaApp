using System;

namespace Cinema.Model.Domain
{
    public class Ticket
    {
        public Guid MovieId { get; protected set; }
        public int Seating { get; protected set; }
        public decimal Price { get; protected set; }
        public Guid? UserId { get; protected set; }
        public string Username { get; protected set; }
        public DateTime? PurchasedAt { get; protected set; }
        public bool Purchased => UserId.HasValue;

        protected Ticket()
        {
        }

        public Ticket(Movie movie, int seating, decimal price)
        {
            MovieId = movie.Id;
            Seating = seating;
            Price = price;
        }

        public void Purchase(User user)
        {
            if(Purchased)
            {
                throw new Exception($"Ticket was already purchased by user: '{Username}' at: {PurchasedAt}'.");
            }
            UserId = user.Id;
            Username = user.Username;
            PurchasedAt = DateTime.UtcNow;
        }

        public void Cancel()
        {
            if(!Purchased)
            {
                throw new Exception($"Ticket was not purchased and can not be canceled.");
            }
            UserId = null;
            Username = null;
            PurchasedAt = null;
        }        
    }
}