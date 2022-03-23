using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Models
{
    public class Genre_Movie
    {
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

    }
}
