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
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _languageService;


        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;

        }
        [Route("Language-Index")]
        public ViewResult Index(int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var data = _languageService.GetDataBySearchInPages(page);
            return View(data);
        }

        [Route("Language-Index")]
        [HttpPost]
        public ViewResult Index(string search, int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewData["SearchString"] = search;
            var data = _languageService.GetDataBySearchInPages(page, search);
            return View(data);
        }

        [Route("Language-Create")]
        public ViewResult Create()
        {
            dynamic model = new Language();
            return View(model);
        }

        [Route("Language-Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Language model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IsSuccess = true;
                await _languageService.Create(model);
                ModelState.Clear();
            }
            return View(model);
        }
        [Route("Language-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _languageService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [Route("Language-Edit/{id:int:min(1)}")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _languageService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [HttpPost]
        [Route("Language-Edit/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(Language model)
        {
            if (ModelState.IsValid)
            {
                TempData["EditSuccess"] = true;
                await _languageService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [Route("Delete-Language")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _languageService.GetById(id);
            if (item == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["DeleteSuccess"] = true;
                await _languageService.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}
