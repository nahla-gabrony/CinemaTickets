using System;
using System.Collections.Generic;

namespace CinemaTickets.Data.ViewModels.BookingDetails
{
    public class BookingTicketsViewModel : BookingDetailsViewModel
    {
        // Movie Details
         public string TheaterName { get; set; }
         public string ScreenName { get; set; }
         public string ScreenDesign { get; set; }

        public String ShowDateString { get; set; }
        public String ShowTimeString { get; set; }
        public List<string> TicketsList { get; set; }
        public List<string> ReservedTickets { get; set; }
        public int TicketsCount { get; set; }
        public int TicketsPrice { get; set; }
        public int TicketPrice { get; set; }
        public string UserId { get; set; }


    }
}
