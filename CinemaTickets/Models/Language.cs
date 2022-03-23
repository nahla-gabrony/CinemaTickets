using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Language Name")]
        [Display(Name = "Language Name")]
        public string LanguageName { get; set; }
    }
}
