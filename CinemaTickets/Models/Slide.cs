using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Models
{
    public class Slide
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Slide Title is required")]
        public string SlideTitle { get; set; }

        [Required(ErrorMessage = "Slide Details is required")]
        public string SlideDetails { get; set; }
        public string SlideImageURL { get; set; }

        public int MovieId { get; set; }
        public bool IsActive { get; set; }
    }
}
