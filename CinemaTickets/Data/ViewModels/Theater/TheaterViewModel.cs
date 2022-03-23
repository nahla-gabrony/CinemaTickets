using CinemaTickets.Models;
using System.Collections.Generic;

namespace CinemaTickets.Data.ViewModels.Theaters
{
    public class TheaterViewModel 
    {
        public int TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string TheaterDetails { get; set; }    
        public string TheaterLocation { get; set; }
        public string ExistPhoto { get; set; }
        public bool IsSuccess { get; set; }
        public List<Show> Shows { get; set; }
        public List<Screen> Screens { get; set; }
        public List<Movie> Movies { get; set; }


    }
}
