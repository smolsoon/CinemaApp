using System;

namespace Cinema.Infrastrucure.Commands.Movies
{
    public class UpdateMovie
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }  
    }
}