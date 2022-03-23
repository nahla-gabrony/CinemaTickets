using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Shows
{
    public class ShowEditViewModel
    {
        
        public int ShowId { get; set; }

        [Required(ErrorMessage = "Please Select the Show Start Date")]
        [Display(Name = "Show Start Date")]
        public DateTime ShowStartDate { get; set; }
        [Required(ErrorMessage = "Please Select the Show End Date")]
        [Display(Name = "Show End Date")]
        public DateTime ShowEndDate { get; set; }

        [Required(ErrorMessage = "Please Select the Movie")]
        [Display(Name = "Movie Name")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please Select the Theater")]
        [Display(Name = "Theater Name")]
        public int TheaterId { get; set; }

        [Required(ErrorMessage = "Please Select the Screen")]
        [Display(Name = "Screen Name")]
        public int ScreenId { get; set; }

        [Required(ErrorMessage = "Please Select the Show Time")]
        [Display(Name = "Show Time")]
        public List<int> TimeId { get; set; } 
      
        public bool IsSuccess { get; set; }
    }
}
