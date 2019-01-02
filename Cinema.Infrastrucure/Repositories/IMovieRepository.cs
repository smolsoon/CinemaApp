using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Model.Domain;

namespace Cinema.Infrastrucure.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> GetAsync(Guid id); 
        Task<Movie> GetAsync(string title);
        Task<IEnumerable<Movie>> BrowseAsync(string title = "");
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(Movie movie);

    }
}