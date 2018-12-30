using System;
using System.Collections.Generic;

namespace Cinema.Model.Domain
{
    public class User 
    {
        private static List<string> _roles = new List<string>
        {
            "user", "admin"
        };
        public Guid Id { get; protected set; }
        public string Username { get; protected set; }
        public string Role { get; protected set; }
        public string Email {get; protected set;}
        public string Password {get; protected set;}
        public DateTime CreatedAt {get; protected set;}

        protected User()
        {}
        public User(Guid id, string role, string username, string email, string password)
        {
            Id = id;
            SetRole(role);
            SetUsername(username);
            SetEmail(email);
            Password = password;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("User can not have an empty username");
            }
            Username = username;
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("User can not have an empty email");
            }
            Email = email;
        }

        public void SetPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("User can not have an empty password");
            }
            Password = password;
        }

        public void SetRole(string role)
        {
            if(string.IsNullOrWhiteSpace(role))
            {
                throw new Exception($"User can not have an empty role.");
            }
            role = role.ToLowerInvariant();
            if(!_roles.Contains(role))
            {
                throw new Exception($"User can not have a role: '{role}'.");
            }
            Role = role;
        }

    }
}