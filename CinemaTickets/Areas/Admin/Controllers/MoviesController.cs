using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaTickets.Areas.Admin.Controllers
{
    [Authorize(Policy  = "AdminManage")]
    [Route("admin")]
    [Area("admin")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService ;
        private readonly ICountryService _countryService;
        private readonly IGenreService _genreService;
        private readonly ILanguageService _languageService;
        private readonly ICrewService _crewService;

        public MoviesController(IMovieService movieService,
                                ICountryService countryService,
                                IGenreService genreService ,
                                ILanguageService languageService,
                                ICrewService crewService)
        {
            _movieService = movieService;
            _countryService = countryService;
            _genreService = genreService;
            _languageService = languageService;
            _crewService = crewService;
        }

        [Route("Movie-Index")]
        public ViewResult Index(int page =1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var data = _movieService.GetDataBySearchInPages(page);
            return View(data);
        }

        [Route("Movie-Index")]
        [HttpPost]
        public ViewResult Index(string search, int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewData["SearchString"] = search;
            var data = _movieService.GetDataBySearchInPages(page, search);
            return View(data);
        }

        [Route("Movie-Create")]
        public async Task<ViewResult> Create()
        {
            dynamic model = new MovieCreateViewModel();
            await GetSelectList();
            return View(model);
        }

        [Route("Movie-Create")]
        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.IsSuccess = true;
                await _movieService.Create(model,"images/movies/");
                ModelState.Clear();
            }
            await GetSelectList();
            return View(model);
        }

        [Route("Movie-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _movieService.GetDetailsByIdAdmin(id);
            if (data == null)
            {
                return View("NotFound");
            }
            await GetSelectList();
            return View(data);
        }

        [Route("Movie-Edit/{id:int:min(1)}")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _movieService.GetDetailsByIdAdmin(id);
            if (data == null)
            {
                return View("NotFound");
            }
            await GetSelectList();
            return View(data);
        }

        [HttpPost]
        [Route("Movie-Edit/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(MovieEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["EditSuccess"] = true;
                await _movieService.Update(model, "images/movies/");
                return RedirectToAction("Index");
            }
            await GetSelectList();
            return View(model);
        }

        [Route("Delete-Movie")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _movieService.GetById(id);
            if (item == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["DeleteSuccess"] = true;
                await _movieService.Delete(id);
                return RedirectToAction("Index");
            }
        }
        private async Task GetSelectList()
        {
            ViewBag.languages = await _languageService.GetAll();
            ViewBag.Countries = await _countryService.GetAll();
            ViewBag.Genres = await _genreService.GetAll();
            ViewBag.Actors = await _crewService.GetAllByType(1);
            ViewBag.Writers = await _crewService.GetAllByType(2);
            ViewBag.Directors = await _crewService.GetAllByType(3);
        }
  

    }
}
