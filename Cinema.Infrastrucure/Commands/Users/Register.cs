using System;

namespace Cinema.Infrastrucure.Commands.Users
{
    public class Register
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public string Username { get; set; }
        public string Role { get; set; }
    }
}