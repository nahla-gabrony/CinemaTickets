using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Slide
{
    public class SlideCreateViewModel 
    {
        public int SlideId { get; set; }

        [Required(ErrorMessage = "Please Enter the  Slide Title")]
        [Display(Name = "Slide Title")]
        public string SlideTitle { get; set; }

        [Required(ErrorMessage = "Please Enter the Slide Details")]
        [Display(Name = "Slide Details")]
        public string SlideDetails { get; set; }
        public IFormFile CoverPhoto { get; set; }

        public bool IsSuccess { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Please Select the Movie Name")]
        [Display(Name = "Movie Name")]
        public int MovieId { get; set; }


    }
}
