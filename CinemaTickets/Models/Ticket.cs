using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int TicketPrice { get; set; }
        public string SeatNumber { get; set; }


        [Column(TypeName = "date")]
        public DateTime ShowDate { get; set; }

        public TimeSpan ShowTime { get; set; }

        //Relationship
        public int ShowId { get; set; }
        [ForeignKey("ShowId")]
        public Show Show { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }


    }
}
