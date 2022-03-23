using CinemaTickets.Data.Repository;
using CinemaTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface IScreenService : IEntityRepository<Screen>
    {
        Task<Screen> GetDetailsById(int id);
        Task Update(Screen model);
        Task Create(Screen model);
        Task<List<Screen>> GetScreenByTheater(int theaterId);
        Task<string> GetScreenName(int screenId);
      
    }
}
