using System.Collections.Generic;

namespace Cinema.Infrastrucure.DTO
{
    public class MovieDetailsDTO : MovieDTO
    {
        public IEnumerable<TicketDTO> Tickets { get; set;} 
    }
}