using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        public bool IsSend { get; set; }

    }
}
