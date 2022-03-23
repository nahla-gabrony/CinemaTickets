using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Account
{
    public class SignUpViewModel
    {

        [Required(ErrorMessage = "Please Enter Your First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your First Name")]
        [Display(Name = "First Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Strong Password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password don't match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Confirm Your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
