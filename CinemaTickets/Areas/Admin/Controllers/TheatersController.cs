using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels.Theaters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaTickets.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminManage")]
    [Route("admin")]
    [Area("admin")]
    public class TheatersController : Controller
    {
        private readonly ITheaterService _theaterService;

        public TheatersController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }
        [Route("Theater-Index")]
        public ViewResult Index(int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var data = _theaterService.GetDataBySearchInPages(page);
            return View(data);
        }

        [Route("Theater-Index")]
        [HttpPost]
        public ViewResult Index(string search, int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewData["SearchString"] = search;
            var data = _theaterService.GetDataBySearchInPages(page, search);
            return View(data);
        }

        [Route("Theater-Create")]
        public ViewResult Create()
        {
         
            dynamic model = new TheaterCreateViewModel();
            return View(model);
        }

        [Route("Theater-Create")]
        [HttpPost]
        public async Task<IActionResult> Create(TheaterCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.IsSuccess = true;
                await _theaterService.Create(model, "images/theaters/");
                ModelState.Clear();
            }
            return View(model);
        }
        [Route("Theater-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _theaterService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [Route("Theater-Edit/{id:int:min(1)}")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _theaterService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [HttpPost]
        [Route("Theater-Edit/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(TheaterEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["EditSuccess"] = true;
                await _theaterService.Update(model, "images/theaters/");
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [Route("Delete-Theater")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _theaterService.GetById(id);
            if (item == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["DeleteSuccess"] = true;
                await _theaterService.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}
