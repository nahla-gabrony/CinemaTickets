using CinemaTickets.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.CrewDetails
{
    public class CrewDetailsEditViewModel : CrewDetailsCreateViewModel
    {
        [Display(Name = "Please Enter the Nationality")]
        public string NationalityName { get; set; }
        public string CrewRoleName { get; set; }
        public string ExistPhoto { get; set; }

        public List<Crew_Gallery> ExistCrewGallery { get; set; }
    }
}
