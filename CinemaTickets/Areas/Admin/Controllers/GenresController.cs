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
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;


        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;

        }
        [Route("Genre-Index")]
        public ViewResult Index(int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var data = _genreService.GetDataBySearchInPages(page);
            return View(data);
        }

        [Route("Genre-Index")]
        [HttpPost]
        public ViewResult Index(string search, int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewData["SearchString"] = search;
            var data = _genreService.GetDataBySearchInPages(page, search);
            return View(data);
        }

        [Route("Genre-Create")]
        public ViewResult Create()
        {
            dynamic model = new Genre();
            return View(model);
        }

        [Route("Genre-Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Genre model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IsSuccess = true;
                await _genreService.Create(model);
                ModelState.Clear();
            }
            return View(model);
        }
        [Route("Genre-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _genreService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [Route("Genre-Edit/{id:int:min(1)}")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _genreService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [HttpPost]
        [Route("Genre-Edit/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(Genre model)
        {
            if (ModelState.IsValid)
            {
                TempData["EditSuccess"] = true;
                await _genreService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [Route("Delete-Genre")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _genreService.GetById(id);
            if (item == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["DeleteSuccess"] = true;
                await _genreService.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}
