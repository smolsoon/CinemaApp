using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.Infrastrucure.DTO;
using Cinema.Infrastrucure.Extensions;
using Cinema.Infrastrucure.Repositories;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDetailsDTO> GetAsync(Guid id)
        {
            var movie = await _movieRepository.GetAsync(id);
            return _mapper.Map<MovieDetailsDTO>(movie);
        }

        public async Task<MovieDetailsDTO> GetAsync(string title)
        {
            var movie = await _movieRepository.GetAsync(title);
            return _mapper.Map<MovieDetailsDTO>(movie);
        }

        public async Task<IEnumerable<MovieDTO>> BrowseAsync(string title = null)
        {
            var movies = await _movieRepository.BrowseAsync(title);
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task AddTicketsAsync(Guid movieId, int amount, decimal price)
        {
            var movie = await _movieRepository.GetOrFailAsync(movieId);
            movie.AddTickets(amount, price);
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task CreateAsync(Guid id, string title, string description, DateTime time)
        {
            var movie = await _movieRepository.GetAsync(title);
            if(movie != null)
            {
                throw new Exception($"Movie titled: '{title}' already exists.");
            }
            movie = new Movie(id, title, description, time);
            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateAsync(Guid id, string title, string description)
        {
            var movie = await _movieRepository.GetAsync(title);
            if(movie != null)
            {
                throw new Exception($"Movie titled: '{title}' already exists.");
            }       
            movie = await _movieRepository.GetOrFailAsync(id);

            await _movieRepository.UpdateAsync(movie);          
        }

        public async Task DeleteAsync(Guid id)
        {
            var movie = await _movieRepository.GetOrFailAsync(id);
            await _movieRepository.DeleteAsync(movie);
        }

    }
}