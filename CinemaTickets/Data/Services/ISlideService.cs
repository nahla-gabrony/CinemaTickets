using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.Slide;
using CinemaTickets.Models;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface ISlideService : IEntityRepository<Slide>
    {
        Task<SlideEditViewModel> GetDetailsById(int id);
        Task Update(SlideEditViewModel model, string folderPath);
        Task Create(SlideCreateViewModel model, string folderPath);
        int CountAllActive();
    }
}
