using CinemaTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICrewService _crewService;

        public MoviesController(IMovieService movieService,
                                ICrewService crewService)
        {
            _movieService = movieService;
            _crewService = crewService;
        }

        [Route("Movies")]
        public async Task<ViewResult> Index()
        {
            var data = await _movieService.GetMovies("now");
            return View(data);
        }

        [Route("Movies/{status}")]
        [HttpPost]
        public async Task<ViewResult> Index(string status)
        {
            var data = await _movieService.GetMovies(status); ;
            return View(data);
        }

        [Route("Movie-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _movieService.GetDetailsById(id);
            if (data == null)
            {
                ViewBag.Message = "Oops.This Movie doesn't exist.";
                return View("NotFound");
            }
            await GetSelectList();
            return View(data);
        }
        private async Task GetSelectList()
        {
            ViewBag.Actors = await _crewService.GetAllByType(1);
            ViewBag.Writers = await _crewService.GetAllByType(2);
            ViewBag.Directors = await _crewService.GetAllByType(3);
        }
    }
}
