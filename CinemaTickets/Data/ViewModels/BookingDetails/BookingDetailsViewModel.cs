using CinemaTickets.Models;
using System;
using System.Collections.Generic;

namespace CinemaTickets.Data.ViewModels.BookingDetails
{
    public class BookingDetailsViewModel
    {
        public int TicketId { get; set; }
        // Movie Details
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string ExistPhoto { get; set; }

        // Ticket Details
        public string SeatNumber { get; set; }
        public DateTime ShowEndDate { get; set; }
        public TimeSpan ShowTime { get; set; }
        public DateTime ShowDate { get; set; }


        // Theater Details
         public int TheaterId { get; set; }
         public int ScreenId { get; set; }



        public List<Theater> Theaters { get; set; }
        public List<Screen> Screens { get; set; }
        public List<Time> Times { get; set; }
        public List<Show> Shows { get; set; }
        public List<Show_Time> Show_times { get; set; }


    }
}
