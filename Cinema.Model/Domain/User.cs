using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinema.Model.Domain {
    public class User {
        [BsonId]
        public Guid _id { get; protected set; }
        public string Username { get; protected set; }
        public string Role { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        public User (Guid id, string role, string username, string email, string password) {
            _id = id;
            Role = role;
            Username = username;
            Email = email;
            Password = password;
        }
    }
}