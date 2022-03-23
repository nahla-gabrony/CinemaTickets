using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Models
{
    public class Theater
    {
        [Key]
        public int Id { get; set; }
        public string TheaterName { get; set; }
        public string TheaterDetails { get; set; }
        public string TheaterLocation { get; set; }
        public string TheaterImageURL { get; set; }

        //Relationship
         public ICollection<Screen> Screens { get; set; }


    }
}
