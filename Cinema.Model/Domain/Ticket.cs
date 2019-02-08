using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinema.Model.Domain {
    public class Ticket {
        [BsonId]
        public Guid Id { get; protected set; } //movie,user
        public Guid MovieId { get; protected set; }
        public string Title { get; protected set; } //movie,user
        public int Seating { get; protected set; } //movie,user
        public decimal Price { get; protected set; } //movie,user
        public Guid? UserId { get; protected set; } //User
        public string Username { get; protected set; } //User
        public bool Available => UserId.HasValue; // Movie

        protected Ticket () { }

        public Ticket (Movie movie, int seating, decimal price) {
            MovieId = movie._id;
            Seating = seating;
            Price = price;
        }
    }
}