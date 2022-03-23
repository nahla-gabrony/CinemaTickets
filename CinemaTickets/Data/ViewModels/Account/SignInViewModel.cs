using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Account
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Strong Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RemberMe { get; set; }


    }
}
