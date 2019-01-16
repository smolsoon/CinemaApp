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
        public async Task<IEnumerable<TicketDetailsDTO>> GetForUserAsync(ObjectId userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var movies = await _movieRepository.BrowseAsync();
            var tickets = new List<TicketDetailsDTO>();

            foreach(var movie in movies)
            {
                var ticket = _mapper.Map<IEnumerable<TicketDetailsDTO>>(movie.GetTicketsPurchasedByUser(user)).ToList();
                ticket.ForEach( x=>
                {
                    x.MovieId = movie._id;
                    x.MovieTitle = movie.Title;
                });
                tickets.AddRange(ticket);
            }
            return tickets;
        }

        public async Task<TicketDTO> GetAsync(ObjectId userId, ObjectId movieId, ObjectId ticketId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var ticket = await  _movieRepository.GetTicketOrFailAsync(movieId,ticketId);
            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task PurchaseAsync(ObjectId userId, ObjectId movieId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var movie = await _movieRepository.GetOrFailAsync(movieId);
            movie.PurchaseTickets(user,amount);
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task CancelAsync(ObjectId userId, ObjectId movieId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var movie = await _movieRepository.GetOrFailAsync(movieId);
            movie.CancelPurchasedTickets(user,amount);
            await _movieRepository.UpdateAsync(movie);
        }
        
    }
}