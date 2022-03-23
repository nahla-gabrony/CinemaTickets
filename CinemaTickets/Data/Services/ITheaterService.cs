using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.Theaters;
using CinemaTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface ITheaterService : IEntityRepository<Theater>
    {
        Task<TheaterEditViewModel> GetDetailsById(int id);
        Task<TheaterViewModel> GetDetailsForUserById(int id);
        Task Update(TheaterEditViewModel model, string folderPath);
        Task Create(TheaterCreateViewModel model, string folderPath);
        Task<IEnumerable<TheaterViewModel>> GetTheaterBySearch(string search = "");
        Task<string> GetTheaterName(int theaterId);
    }
}
