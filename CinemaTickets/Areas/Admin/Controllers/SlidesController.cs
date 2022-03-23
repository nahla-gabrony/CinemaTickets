using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels.Slide;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaTickets.Areas.Admin.Controllers
{

    [Authorize(Policy = "AdvertisingManage")]
    [Route("admin")]
    [Area("admin")]
    public class SlidesController : Controller
    {
        private readonly ISlideService _slideService;
        private readonly IMovieService _movieService;

        public SlidesController(ISlideService slideService,IMovieService movieService)
        {
            _slideService = slideService;
            _movieService = movieService;
        }
        [Route("Slide-Index")]
        public ViewResult Index(int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var data = _slideService.GetDataBySearchInPages(page);
            return View(data);
        }

        [Route("Slide-Index")]
        [HttpPost]
        public ViewResult Index(string search, int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewData["SearchString"] = search;
            var data = _slideService.GetDataBySearchInPages(page, search);
            return View(data);
        }

        [Route("Slide-Create")]
        public async Task<ViewResult> Create()
        {
            ViewBag.Movies = await _movieService.GetAll();
            dynamic model = new SlideCreateViewModel();
            return View(model);
        }

        [Route("Slide-Create")]
        [HttpPost]
        public async Task<IActionResult> Create(SlideCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.IsSuccess = true;
                await _slideService.Create(model, "images/slides/");
                ModelState.Clear();
            }
            ViewBag.Movies = await _movieService.GetAll();
            return View(model);
        }
        [Route("Slide-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _slideService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            ViewBag.Movies = await _movieService.GetAll();
            return View(data);
        }

        [Route("Slide-Edit/{id:int:min(1)}")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _slideService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            ViewBag.Movies = await _movieService.GetAll();
            return View(data);
        }

        [HttpPost]
        [Route("Slide-Edit/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(SlideEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["EditSuccess"] = true;
                await _slideService.Update(model, "images/slides/");
                return RedirectToAction("Index");
            }
            ViewBag.Movies = await _movieService.GetAll();
            return View(model);
        }


        [Route("Delete-Slide")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _slideService.GetById(id);
            if (item == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["DeleteSuccess"] = true;
                await _slideService.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}

