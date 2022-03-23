using CinemaTickets.Data.ViewModels.Email;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface IEmailService
    {
        Task SendEmailforConfirmationEmail(UserEmailOptionsViewModel model);
        Task SendEmailforForgotPassword(UserEmailOptionsViewModel model);
    }
}