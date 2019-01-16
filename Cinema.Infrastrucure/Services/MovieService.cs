using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.Infrastrucure.DTO;
using Cinema.Infrastrucure.Extensions;
using Cinema.Infrastrucure.Repositories;
using Cinema.Model.Domain;
using MongoDB.Bson;

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

        public async Task<MovieDetailsDTO> GetAsync(string id)
        {
            var movie = await _movieRepository.GetAsync(id);
            return _mapper.Map<MovieDetailsDTO>(movie);
        }

        public async Task<IEnumerable<MovieDTO>> BrowseAsync()
        {
            var movies = await _movieRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task AddTicketsAsync(string movieId, int amount, decimal price)
        {
            var movie = await _movieRepository.GetOrFailAsync(movieId);
            movie.AddTickets(amount, price);
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task CreateAsync(string id, string title, string description, string type, string director, string producer, DateTime dateTime)
        {
            var movie = await _movieRepository.GetAsync(id);
            if(movie != null)
            {
                throw new Exception($"Movie titled: '{title}' already exists.");
            }
            movie = new Movie(id , title, description,type,director,producer, dateTime);
            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateAsync(string id, string title, string description)
        {
            var movie = await _movieRepository.GetAsync(id);
            if(movie != null)
            {
                throw new Exception($"Movie titled: '{title}' already exists.");
            }       
            movie = await _movieRepository.GetOrFailAsync(id);

            await _movieRepository.UpdateAsync(movie);          
        }

        public async Task DeleteAsync(string id)
        {
            var movie = await _movieRepository.GetOrFailAsync(id);
            await _movieRepository.DeleteAsync(movie);
        }

        public Task DeleteAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }
    }
}