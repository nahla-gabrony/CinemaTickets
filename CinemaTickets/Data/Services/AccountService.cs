using CinemaTickets.Data.ViewModels.Account;
using CinemaTickets.Data.ViewModels.Email;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class AccountService :IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userServise;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                IUserService userServise,
                                IEmailService emailService,
                                IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userServise = userServise;
            _emailService = emailService;
            _configuration = configuration;
        }
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> CreateAccount(SignUpViewModel model)
        {
            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName =model.Email,
                Email = model.Email,
            };
            var result= await _userManager.CreateAsync(user, model.Password); 
           
            if (result.Succeeded)
            {
               await GenerateEmailConfirmationToken(user);
            }

            return result;
        }

        public async Task GenerateEmailConfirmationToken(ApplicationUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendConfirmationEmail(user, token);
            }
        }

        public async Task GenerateForgotPasswordToken(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPassword(user, token);
            }
        }

        public async Task<SignInResult> PasswordSignIn(SignInViewModel model)
        {
          return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemberMe,false);
        }
        public async Task SignOut()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangeUserPassword(ChangePasswordViewModel model)
        {
            var userId = _userServise.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
             
        }
        public async Task<IdentityResult> ConfirmEmail(string uid , string token)
        {
            var user = await _userManager.FindByIdAsync(uid);
            return await _userManager.ConfirmEmailAsync(user, token);
        }
        public async Task<IdentityResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            return await _userManager.ResetPasswordAsync(user,model.Token, model.NewPassword);
        }

        private async Task SendConfirmationEmail(ApplicationUser user , string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationEmail = _configuration.GetSection("Application:ConfirmationEmail").Value;
            UserEmailOptionsViewModel options = new UserEmailOptionsViewModel()
            {
                ToEmails = new List<string>() {user.Email },
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain+confirmationEmail, user.Id , token))
                }
            };

            await _emailService.SendEmailforConfirmationEmail(options);
        }

        private async Task SendForgotPassword(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationEmail = _configuration.GetSection("Application:ForgotPassword").Value;
            UserEmailOptionsViewModel options = new UserEmailOptionsViewModel()
            {
                ToEmails = new List<string>() { user.Email },
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain+confirmationEmail, user.Id , token))
                }
            };

            await _emailService.SendEmailforForgotPassword(options);
        }
    }
}
