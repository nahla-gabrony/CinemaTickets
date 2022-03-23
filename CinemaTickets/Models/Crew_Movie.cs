using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Models
{
    public class Crew_Movie
    {
        public int CrewId { get; set; }
        [ForeignKey("CrewId")]
        public Crew Crew { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }
}
