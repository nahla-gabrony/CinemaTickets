using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Account
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Token { get; set; }

        [Required(ErrorMessage = "Please Enter Strong Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password don't match")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please Confirm Your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool IsSuccess { get; set; }
    }
}
