using System;

namespace Cinema.Model.Domain
{
    public class User : Entity
    {
        public string Name {get; protected set;}
        public string Email {get; protected set;}
        public string Password {get; protected set;}
        public DateTime CreatedAt {get; protected set;}

        protected User()
        {}

        public User(Guid id, string role, string name, string email, string password)
        {
            GuidId = id;
            SetName(name);
            SetEmail(email);
            Password = password;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("User can not have an empty name");
            }
            Name = name;
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
    }
}