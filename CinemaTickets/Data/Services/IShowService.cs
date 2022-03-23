using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.BookingDetails;
using CinemaTickets.Data.ViewModels.Shows;
using CinemaTickets.Models;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface IShowService : IEntityRepository<Show>
    {
        Task<ShowEditViewModel> GetDetailsById(int id);
        Task Update(ShowEditViewModel model);
        Task Create(ShowEditViewModel model);
        Task<int> GetShowId(BookingDetailsViewModel model);
    }
}
