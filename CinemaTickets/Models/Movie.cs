using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Movie Name")]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "Please Enter the Movie Description")]
        [Display(Name = "Movie Description")]
        public string MovieDescription { get; set; }

        public string MovieImageURL { get; set; }

        [Required(ErrorMessage = "Please Enter the Movie Rate")]
        [Display(Name = "Movie Rate")]
        public string MovieRate { get; set; }

        [Required(ErrorMessage = "Please Enter the Movie Running Time")]
        [Display(Name = "Movie Running Time")]
        public string MovieRunningTime { get; set; }

        [Required(ErrorMessage = "Please Enter the Movie Release Date")]
        [Display(Name = "Movie Release Date")]
        [Column(TypeName = "date")]
        public DateTime MovieReleaseDate { get; set; }

        //Relationship
        [Display(Name = "Movie Language")]
        public int? LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
       
        [Display(Name = "Movie Country")]
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public ICollection<Crew_Movie> Crew_Movies { get; set; }
        public ICollection<Genre_Movie> Genres_Movies { get; set; }
        public ICollection<Show> Show { get; set; }
        public ICollection<Movie_Gallery> MovieGallary { get; set; }

  
    }

    
}
