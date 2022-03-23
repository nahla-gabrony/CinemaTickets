using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Please Enter Old Password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please Enter New Password")]
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
