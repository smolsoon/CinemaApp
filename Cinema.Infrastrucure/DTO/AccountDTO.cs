using System;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.DTO
{
    public class AccountDTO
    {
        public ObjectId _id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password {get; set;}
 
   
    }
}