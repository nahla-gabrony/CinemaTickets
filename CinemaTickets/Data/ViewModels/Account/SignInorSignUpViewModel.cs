using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace CinemaTickets.Data.ViewModels.Account
{
    public class SignInorSignUpViewModel
    {
        public  SignInViewModel SignIn{ get; set; }
        public SignUpViewModel SignUp { get; set; }

        public bool SignUpCheck { get; set; }

        public IList<AuthenticationScheme> ExternalLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
