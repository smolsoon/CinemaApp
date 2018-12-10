using System;

namespace Cinema.Model.Domain
{
    public class Photo : Entity
    {
        public string Url { get; set; }
        public Movie movie { get; set; }
        public Guid MovieId { get; set; }
    }
}