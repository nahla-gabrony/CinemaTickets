using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Theaters
{
    public class TheaterCreateViewModel
    {
        public int TheaterId { get; set; }

        [Required(ErrorMessage = "Please Enter the  Theater Name")]
        [Display(Name = "Theater Name")]
        public string TheaterName { get; set; }

        [Required(ErrorMessage = "Please Enter the Theater Details")]
        [Display(Name = "Theater Details")]
        public string TheaterDetails { get; set; }    
        
        [Required(ErrorMessage = "Please Enter the Theater Location")]
        [Display(Name = "Theater Location")]
        public string TheaterLocation { get; set; }
        public IFormFile CoverPhoto { get; set; }

        public bool IsSuccess { get; set; }


    }
}
