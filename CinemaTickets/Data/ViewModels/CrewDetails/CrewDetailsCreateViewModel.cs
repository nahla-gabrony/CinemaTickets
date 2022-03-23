using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.CrewDetails
{
    public class CrewDetailsCreateViewModel 
    {
        public int CrewId { get; set; }

        [Required(ErrorMessage = "Please Enter the Name")]
        [Display(Name = "Crew Name")]
        public string CrewName { get; set; }

        [Required(ErrorMessage = "Please Enter the  Description")]
        [Display(Name = "Crew Description")]
        public string CrewBiography { get; set; }

        [Required(ErrorMessage = "Please Enter the Date of Birth")]
        [Display(Name = "Date of Birth")]
        public DateTime CrewDateofBirth { get; set; }

        [Required(ErrorMessage = "Please Select the Nationality")]
        [Display(Name = "Nationality")]
        public int? NationalityId { get; set; }

        [Required(ErrorMessage = "Please Select the Crew Role")]
        [Display(Name = "Crew Role")]
        public int? CrewRoleId { get; set; }

        public IFormFile CoverPhoto { get; set; }

        public IFormFileCollection GallaryPhotos { get; set; }

        public bool IsSuccess { get; set; }


    }
}
