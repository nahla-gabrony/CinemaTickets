using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Genre Name")]
        [Display(Name = "Genre Name")]
        public string GenreName { get; set; }

        //Relationship
        public ICollection<Genre_Movie> Genres_Movies { get; set; }
    }
}
