namespace CinemaTickets.Data.ViewModels.BookingDetails
{
    public class TicketsProfitsViewModel 
    {
    
         public int TheaterId { get; set; }
         public string TheaterName { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int DailyTickets { get; set; }
         public int DailyProfit { get; set; }
        public int MonthlyProfit { get; set; }
  


    }
}
