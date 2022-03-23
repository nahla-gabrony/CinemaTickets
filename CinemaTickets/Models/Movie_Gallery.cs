using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Models
{
    public class Movie_Gallery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ImageURL { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

    }
}
