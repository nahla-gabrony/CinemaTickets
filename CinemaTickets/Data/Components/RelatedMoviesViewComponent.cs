using CinemaTickets.Data.Services;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Components
{
    public class RelatedMoviesViewComponent : ViewComponent
    {
        private readonly IMovieService _movieService;

        public RelatedMoviesViewComponent(IMovieService movieService)
        {
           _movieService = movieService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int crewId = 0, int movieId = 0)
        {
            if (crewId!= 0)
            {
                return View(await _movieService.CrewFilmography(crewId));
            }
            if (movieId !=0) 
            {
                return View(await _movieService.Related(movieId));
            }

            return null;

        }
    }
}
