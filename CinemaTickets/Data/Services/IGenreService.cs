using CinemaTickets.Data.Repository;
using CinemaTickets.Models;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface IGenreService : IEntityRepository<Genre>
    {
        Task<Genre> GetDetailsById(int id);
        Task Update(Genre model);
        Task Create(Genre model);
    }
}
