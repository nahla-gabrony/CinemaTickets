using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Models
{
    public class Screen
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Please Enter the Screen Name")]
        [Display(Name = "Screen Name")]
        public string ScreenName { get; set; }


        //Relationship
        public ICollection<Show> Show { get; set; }


        [Required(ErrorMessage = "Please Select the Theater")]
        [Display(Name = "Theater Name")]
        public int TheaterId { get; set; }
        [ForeignKey("TheaterId")]
        public Theater Theater { get; set; }

    }
}
