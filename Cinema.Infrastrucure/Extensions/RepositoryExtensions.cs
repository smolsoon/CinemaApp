using System;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Infrastrucure.Repositories;
using Cinema.Model.Domain;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Movie> GetOrFailAsync(this IMovieRepository repository, string id)
        {
            var movie = await repository.GetAsync(id);
            if(movie == null)
            {
                throw new Exception($"Moive with id: '{id}' does not exist.");
            }

            return movie;            
        }

        public static async Task<User> GetOrFailAsync(this IUserRepository repository, ObjectId id)
        {
            var user = await repository.GetAsync(id);
            if(user == null)
            {
                throw new Exception($"User with id: '{id}' does not exist.");
            }

            return user;            
        }

        public static async Task<Ticket> GetTicketOrFailAsync(this IMovieRepository repository, string movieId,
            string ticketId)
        {
            var movie = await repository.GetOrFailAsync(movieId);
            var ticket = movie.Tickets.SingleOrDefault(x => x.Id == ticketId);
            if(ticket == null)
            {
                throw new Exception($"Ticket with id: '{ticketId}' was not found for event: '{movie.Title}'");
            }

            return ticket;            
        }       
    }
}