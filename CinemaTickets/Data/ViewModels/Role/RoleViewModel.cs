using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Role
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Please Enter Role Name")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; } = new List<string>();
        public bool IsSuccess { get; set; }

    }
}
