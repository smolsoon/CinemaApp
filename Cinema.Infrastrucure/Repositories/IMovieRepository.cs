using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Infrastrucure.DTO;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieDTO>> GetMovies();
        Task<MovieDTO> Get(string title);
        Task Create(MovieDTO movie);
        Task<bool> Update(MovieDTO movie);
        Task<bool> Delete(string title);
    }
}