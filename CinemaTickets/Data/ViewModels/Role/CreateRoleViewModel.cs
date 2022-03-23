using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Role
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Please Enter Role Name")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public bool IsSuccess { get; set; }


    }
}
