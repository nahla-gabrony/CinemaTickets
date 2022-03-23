using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels.Shows;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminManage")]
    [Route("admin")]
    [Area("admin")]
    public class ShowsController : Controller
    {
        private readonly IShowService _showService;
        private readonly IMovieService _movieService;
        private readonly ITheaterService _theaterService;
        private readonly ITimeService _timeService;
        private readonly IScreenService _screenService;

        public ShowsController(IShowService showService,
                               IMovieService movieService,
                               ITheaterService theaterService,
                               ITimeService timeService,
                               IScreenService screenService)
        {
            _showService = showService;
            _movieService = movieService;
           _theaterService = theaterService;
            _timeService = timeService;
            _screenService = screenService;
        }
        [Route("Show-Index")]
        public ViewResult Index(int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var data = _showService.GetDataBySearchInPages(page);
            return View(data);
        }

        [Route("Show-Index")]
        [HttpPost]
        public ViewResult Index(string search, int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewData["SearchString"] = search;
            var data = _showService.GetDataBySearchInPages(page, search);
            return View(data);
        }

        [Route("Show-Create")]
        public async Task<ViewResult> Create()
        {
            dynamic model = new ShowEditViewModel();
            await GetSelectList();
            return View(model);
        }

        [Route("Show-Create")]
        [HttpPost]
        public async Task<IActionResult> Create(ShowEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IsSuccess = true;
                await _showService.Create(model);
                ModelState.Clear();
            }
            await GetSelectList();
            return View(model);
        }
        [Route("Show-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _showService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            await GetSelectList();
            return View(data);
        }

        [Route("Show-Edit/{id:int:min(1)}")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _showService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            await GetSelectList();
            return View(data);
        }

        [HttpPost]
        [Route("Show-Edit/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(ShowEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["EditSuccess"] = true;
                await _showService.Update(model);
                return RedirectToAction("Index");
            }
            await GetSelectList();
            return View(model);
        }


        [Route("Delete-Show")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _showService.GetById(id);
            if (item == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["DeleteSuccess"] = true;
                await _showService.Delete(id);
                return RedirectToAction("Index");
            }
        }
        private async Task GetSelectList()
        {
            ViewBag.Movies = await _movieService.GetAll();
            ViewBag.Theaters = await _theaterService.GetAll();
            ViewBag.Screens = await _screenService.GetAll();

            var ShowTimes = await _timeService.GetAll();
            List<SelectListItem> timeList = new List<SelectListItem>();
            foreach (var time in ShowTimes)
            {
                DateTime Newtime = DateTime.Today.Add(time.MovieTime);
                timeList.Add(new SelectListItem
                {
                    Text = Newtime.ToString("hh:mm tt"),
                    Value = time.Id.ToString()
                });
            }
            ViewBag.Times = timeList;

        }
        // Json Function
        [Route("GetScreenByTheaterId")]
        public async Task<JsonResult> GetScreenByTheaterId(int theaterId)
        {
            var screenData = await _screenService.GetScreenByTheater(theaterId);

            var ScreenList = new SelectList(screenData, "Id", "ScreenName").ToList<SelectListItem>();
            ScreenList.Insert(0, new SelectListItem() { Value = "null", Text = "Choose Screen" });

            return Json(ScreenList);
        }
    }
}
