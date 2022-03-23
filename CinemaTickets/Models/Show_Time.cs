using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Models
{
    public class Show_Time
    {
        public int ShowId { get; set; }
        [ForeignKey("ShowId")]
        public Show Show { get; set; }

        public int TimeId { get; set; }
        [ForeignKey("TimeId")]
        public Time Time { get; set; }
    }
}
