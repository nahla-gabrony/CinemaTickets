using CinemaTickets.Data.ViewModels.Account;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface IAccountService
    {
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<IdentityResult> CreateAccount(SignUpViewModel model);
        Task GenerateEmailConfirmationToken(ApplicationUser user);
        Task GenerateForgotPasswordToken(ApplicationUser user);
        Task<SignInResult> PasswordSignIn(SignInViewModel model);
        Task SignOut();
        Task<IdentityResult> ChangeUserPassword(ChangePasswordViewModel model);
        Task<IdentityResult> ConfirmEmail(string uid, string token);
        Task<IdentityResult> ResetPassword(ResetPasswordViewModel model);
      

    }
}
