using System;

namespace Cinema.Infrastrucure.DTO
{
    public class AccountDTO
    {
        public Guid Idd { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password {get; set;}
 
   
    }
}