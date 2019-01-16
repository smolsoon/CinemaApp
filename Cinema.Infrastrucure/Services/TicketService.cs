using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.Infrastrucure.DTO;
using Cinema.Infrastrucure.Extensions;
using Cinema.Infrastrucure.Repositories;
using MongoDB.Bson;

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
        public async Task<IEnumerable<TicketDTO>> GetForUserAsync(ObjectId userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var movies = await _movieRepository.BrowseAsync();
            var tickets = new List<TicketDTO>();

            foreach(var movie in movies)
            {
                var ticket = _mapper.Map<IEnumerable<TicketDTO>>(movie.GetTicketsPurchasedByUser(user)).ToList();
                ticket.ForEach( x=>
                {
                    x.MovieId = movie._id;
                });
                tickets.AddRange(ticket);
            }
            return tickets;
        }

        public async Task<TicketDetailsDTO> GetAsync(ObjectId userId, string movieId, string ticketId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var ticket = await  _movieRepository.GetTicketOrFailAsync(movieId,ticketId);
            return _mapper.Map<TicketDetailsDTO>(ticket);
        }

        public async Task PurchaseAsync(ObjectId userId, string movieId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var movie = await _movieRepository.GetOrFailAsync(movieId);
            movie.PurchaseTickets(user,amount);
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task CancelAsync(ObjectId userId, string movieId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var movie = await _movieRepository.GetOrFailAsync(movieId);
            movie.CancelPurchasedTickets(user,amount);
            await _movieRepository.UpdateAsync(movie);
        }
    }
}