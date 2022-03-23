using CinemaTickets.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Movies
{
    public class MovieEditViewModel : MovieCreateViewModel
    {
       
        [Display(Name = "Movie Language")]
        public string LanguageName { get; set; }
       
        [Display(Name = "Movie Country")]
        public string CountryName { get; set; }
        public string GenresName { get; set; }

        public string ExistPhoto { get; set; }
        public List<Movie_Gallery> ExistMovieGallery { get; set; }
        public List<Crew_Movie> ExistCrew { get; set; }
        public List<Show> Shows { get; set; }


   
      
    }
}
