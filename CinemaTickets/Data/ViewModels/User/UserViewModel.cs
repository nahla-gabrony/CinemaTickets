using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.User
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool IsSuccess { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
        public List<string> Claims { get; set; } = new List<string>();
    }
}
