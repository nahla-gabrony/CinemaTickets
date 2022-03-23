using CinemaTickets.Data.Services;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaTickets.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminManage")]
    [Route("admin")]
    [Area("admin")]
    public class ScreensController : Controller
    {
        private readonly IScreenService _screenService;
        private readonly ITheaterService _theaterService;

        public ScreensController(IScreenService screenService,
                                 ITheaterService theaterService)
        {
            _screenService = screenService;
           _theaterService = theaterService;
        }
        [Route("Screen-Index")]
        public ViewResult Index(int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var data = _screenService.GetDataBySearchInPages(page);
            return View(data);
        }

        [Route("Screen-Index")]
        [HttpPost]
        public ViewResult Index(string search, int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewData["SearchString"] = search;
            var data = _screenService.GetDataBySearchInPages(page, search);
            return View(data);
        }

        [Route("Screen-Create")]
        public async Task<ViewResult> Create()
        {
            dynamic model = new Screen();
            await GetSelectList();
            return View(model);
        }

        [Route("Screen-Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Screen model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IsSuccess = true;
                await _screenService.Create(model);
                ModelState.Clear();
            }
            await GetSelectList();
            return View(model);
        }
        [Route("Screen-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _screenService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            await GetSelectList();
            return View(data);
        }

        [Route("Screen-Edit/{id:int:min(1)}")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _screenService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            await GetSelectList();
            return View(data);
        }

        [HttpPost]
        [Route("Screen-Edit/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(Screen model)
        {
            if (ModelState.IsValid)
            {
                TempData["EditSuccess"] = true;
                await _screenService.Update(model);
                return RedirectToAction("Index");
            }
            await GetSelectList();
            return View(model);
        }


        [Route("Delete-Screen")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _screenService.GetById(id);
            if (item == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["DeleteSuccess"] = true;
                await _screenService.Delete(id);
                return RedirectToAction("Index");
            }
        }
        private async Task GetSelectList()
        {
            ViewBag.Theaters = await _theaterService.GetAll();
        }
    }
}
