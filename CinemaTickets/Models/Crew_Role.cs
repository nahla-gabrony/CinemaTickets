using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Models
{
    public class Crew_Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Crew Role Name")]
        [Display(Name = "Crew Role Name")]
        public string CrewRoleName { get; set; }

    

    }
}
