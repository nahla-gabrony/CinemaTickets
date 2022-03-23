using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.Movies;
using CinemaTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface IMovieService : IEntityRepository<Movie>
    {
        Task<IEnumerable<Movie>> CrewFilmography(int crewId);
        Task<MovieEditViewModel> GetDetailsById(int id);
        Task<MovieEditViewModel> GetDetailsByIdAdmin(int id);
        Task Update(MovieEditViewModel model, string folderPath);
        Task Create(MovieCreateViewModel model, string folderPath);
        Task<IEnumerable<Movie>> GetMovies(string search);
        Task<IEnumerable<Movie>> Related(int movieId);
    }
}
