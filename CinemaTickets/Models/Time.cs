using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Models
{
    public class Time
    {
        [Key]
        public int Id { get; set; }
        public TimeSpan MovieTime { get; set; }


        //Relationship
        public ICollection<Show_Time> Show_Time { get; set; }
    }
}
