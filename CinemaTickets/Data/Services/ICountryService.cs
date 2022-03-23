using CinemaTickets.Data.Repository;
using CinemaTickets.Models;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface ICountryService : IEntityRepository<Country>
    {
        Task<Country> GetDetailsById(int id);
        Task Update(Country model);
        Task Create(Country model);
    }
}
