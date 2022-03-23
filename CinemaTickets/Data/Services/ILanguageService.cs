using CinemaTickets.Data.Repository;
using CinemaTickets.Models;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface ILanguageService : IEntityRepository<Language>
    {
        Task<Language> GetDetailsById(int id);
        Task Update(Language model);
        Task Create(Language model);
    }
}
