using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Model.Domain;

namespace Cinema.Model.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> Get(string title);
        Task Create(Movie movie);
        Task<bool> Update(Movie movie);
        Task<bool> Delete(string title);
    }
}