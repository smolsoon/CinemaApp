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
            cfg.CreateMap<Movie,MovieDetailsDTO>();
                // .ForMember(x => x.AvailableTicketsCount, m => m.MapFrom(p => p.GetAvailableTickets().Count()))
                // .ForMember(x => x.PurchasedTicketsCount , m => m.MapFrom(p => p.GetPurchasedTickets().Count()))
                // .ForMember(x => x.TicketsCount, m => m.MapFrom(p => p.GetTickets().Count()));
            cfg.CreateMap<Movie,MovieDTO>();
            cfg.CreateMap<Ticket,TicketMovieDTO>();
            cfg.CreateMap<Ticket,TicketUserDTO>();
        }).CreateMapper();

        
    }
}