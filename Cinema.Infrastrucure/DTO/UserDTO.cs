using System;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.DTO
{
    public class UserDTO
    {
        public ObjectId Id {get; set;}
        public Guid GuidId {get; set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public DateTime CreatedAt {get;set;}
    }
}