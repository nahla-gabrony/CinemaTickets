using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShowStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShowEndDate { get; set; }
       
        //Relationship
        public ICollection<Ticket> Ticket { get; set; }
        public ICollection<Show_Time> Show_Time { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
      
        public int ScreenId { get; set; }
        [ForeignKey("ScreenId")]
        public Screen Screen { get; set; }

    }
}
