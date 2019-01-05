using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.Infrastrucure.DTO;
using Cinema.Infrastrucure.Extensions;
using Cinema.Infrastrucure.Repositories;

namespace Cinema.Infrastrucure.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public TicketService(IUserRepository userRepository, IMovieRepository movieRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TicketDetailsDTO>> GetForUserAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var movies = await _movieRepository.BrowseAsync();
            var tickets = new List<TicketDetailsDTO>();

            foreach(var movie in movies)
            {
                var ticket = _mapper.Map<IEnumerable<TicketDetailsDTO>>(movie.GetTicketsPurchasedByUser(user)).ToList();
                ticket.ForEach( x=>
                {
                    x.MovieId = movie.Idd;
                    x.MovieTitle = movie.Title;
                });
                tickets.AddRange(ticket);
            }
            return tickets;
        }

        public async Task<TicketDTO> GetAsync(Guid userId, Guid movieId, Guid ticketId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var ticket = await  _movieRepository.GetTicketOrFailAsync(movieId,ticketId);
            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task PurchaseAsync(Guid userId, Guid movieId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var movie = await _movieRepository.GetOrFailAsync(movieId);
            movie.PurchaseTickets(user,amount);
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task CancelAsync(Guid userId, Guid movieId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var movie = await _movieRepository.GetOrFailAsync(movieId);
            movie.CancelPurchasedTickets(user,amount);
            await _movieRepository.UpdateAsync(movie);
        }
        
    }
}