using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Models
{
    public class Crew_Gallery
    {
        public int Id { get; set; }

        public string ImageURL { get; set; }

        public int CrewId { get; set; }
        [ForeignKey("CrewId")]
        public Crew Crew { get; set; }

    }
}
