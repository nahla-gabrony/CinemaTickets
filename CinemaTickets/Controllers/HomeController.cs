using CinemaTickets.Data.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ITheaterService _theaterService;
        private readonly ICrewService _crewService;
        private readonly ISlideService _slideService;

        public HomeController(IMovieService movieService,
                              ITheaterService theaterService,
                              ICrewService crewService,
                             ISlideService slideService)
        {
            _movieService = movieService;
            _theaterService = theaterService;
            _crewService = crewService;
            _slideService = slideService;
        }
    
        public async Task<ViewResult> Index()
        {
            dynamic Model = new ExpandoObject();
            Model.SlidesCounter =  _slideService.CountAllActive();
            Model.Slides = await _slideService.GetAll();
            Model.Movies = await _movieService.GetMovies("now");
            return View(Model);
        }
        [Route("{status}")]
        [HttpPost]
        public async Task<ViewResult> Index(string status)
        {
            dynamic Model = new ExpandoObject();
            Model.SlidesCounter = _slideService.CountAllActive();
            Model.Slides = await _slideService.GetAll();
            Model.Movies = await _movieService.GetMovies(status);
            
          
            return View(Model);
        }

        [Route("Search")]
        public async Task<ViewResult> Search(string search)
        {
            ViewData["SearchString"] = search;
            dynamic Model = new ExpandoObject();
            Model.Movies = await _movieService.GetDataBySearch(search);
            Model.Theaters = await _theaterService.GetDataBySearch(search);
            Model.Crews = await _crewService.GetDataBySearch(search);
            return View(Model);
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
