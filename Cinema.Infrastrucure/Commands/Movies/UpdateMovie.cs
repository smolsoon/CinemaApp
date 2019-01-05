using System;

namespace Cinema.Infrastrucure.Commands.Movies
{
    public class UpdateMovie
    {
        public Guid MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}