using System.Linq;
using AutoMapper;
using Cinema.Infrastrucure.DTO;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.Settings
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Initialize() => new MapperConfiguration (cfg => {
            cfg.CreateMap<User, AccountDTO>();
            cfg.CreateMap<Movie,MovieDTO>();
            cfg.CreateMap<Movie,MovieDetailsDTO>();
            cfg.CreateMap<Ticket,TicketDTO>();
        }).CreateMapper();

        
    }
}