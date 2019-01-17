using System;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.DTO
{
    public class MovieDTO
    {
        public Guid _id { get; set; }
        public string Title { get; set; } 
        public string Type { get; set; } 
        public DateTime DateTime { get; set;}    
    }
}