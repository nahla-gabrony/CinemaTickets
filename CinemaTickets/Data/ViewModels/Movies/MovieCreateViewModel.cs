using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.ViewModels.Movies
{
    public class MovieCreateViewModel 
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please Enter the Movie Name")]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Please Enter the Movie Description")]
        [Display(Name = "Movie Description")]
        public string MovieDescription { get; set; }
        [Required(ErrorMessage = "Please Enter the Movie Rate")]
        [Display(Name = "Movie Rate")]
        public string MovieRate { get; set; }
        [Required(ErrorMessage = "Please Enter the Movie Running Time")]
        [Display(Name = "Movie Running Time")]
        public string MovieRunningTime { get; set; }
        [Required(ErrorMessage = "Please Enter the Movie Release Date")]
        [Display(Name = "Movie Release Date")]
        public DateTime MovieReleaseDate { get; set; }
        [Required(ErrorMessage = "Please Select the Movie Language")]
        [Display(Name = "Movie Language")]
        public int? LanguageId { get; set; }
        [Required(ErrorMessage = "Please Select the Movie Country")]
        [Display(Name = "Movie Country")]
        public int? CountryId { get; set; }
        [Display(Name = "Movie Genres")]
        public List<int> GenresId { get; set; } 
        [Display(Name = "Movie Actors")]
        public List<int> ActorsId { get; set; }
        [Display(Name = "Movie Writers")]
        public List<int> WritersId { get; set; }
        [Display(Name = "Movie Directors")]
        public List<int> DirectorsId { get; set; }
        public IFormFile CoverPhoto { get; set; }
        public IFormFileCollection GallaryPhotos { get; set; }
        public bool IsSuccess { get; set; }
    }
}
