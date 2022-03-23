using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.CrewDetails;
using CinemaTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface ICrewService : IEntityRepository<Crew>
    {
        PagedResult<Crew> GetDataBySearchInPages(int page, string search = "", int crewType = 0);

        Task<IEnumerable<Crew>> GetAllByType(int crewType);

        Task<CrewDetailsEditViewModel> GetDetailsById(int id);
        Task Update(CrewDetailsEditViewModel model, string folderPath);
        Task Create(CrewDetailsCreateViewModel model, string folderPath);
    }
}
