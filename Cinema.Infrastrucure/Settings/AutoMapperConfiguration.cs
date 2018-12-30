using System.Linq;
using AutoMapper;
using Cinema.Infrastrucure.DTO;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.Settings
{
    public static class AutoMapperConfiguration
    {
        // public static IMapper Initialize() => new MapperConfiguration (cfg => {
        //     cfg.CreateMap<Movie,MovieDTO>()
        //         .ForMember(x=>x.AvailableTicketsCount, m=>m.MapFrom(p=>p.AvailableTickets.Count()))
        //         .ForMember(x=>x.PurchasedTicketsCount,m=>m.MapFrom(p=>p.PurchasedTickets.Count()))
        //         .ForMember(x=>x.TicketsCount, m=>m.MapFrom(p=>p.Tickets.Count()));
        //     cfg.CreateMap<User, UserDTO>();
        // }).CreateMapper();

        
    }
}