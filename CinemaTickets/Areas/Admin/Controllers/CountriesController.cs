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
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;


        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;

        }
        [Route("Country-Index")]
        public ViewResult Index(int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var data = _countryService.GetDataBySearchInPages(page);
            return View(data);
        }

        [Route("Country-Index")]
        [HttpPost]
        public ViewResult Index(string search, int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewData["SearchString"] = search;
            var data = _countryService.GetDataBySearchInPages(page, search);
            return View(data);
        }

        [Route("Country-Create")]
        public ViewResult Create()
        {
            dynamic model = new Country();
            return View(model);
        }

        [Route("Country-Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Country model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IsSuccess = true;
                await _countryService.Create(model);
                ModelState.Clear();
            }
            return View(model);
        }
        [Route("Country-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _countryService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [Route("Country-Edit/{id:int:min(1)}")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _countryService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [HttpPost]
        [Route("Country-Edit/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(Country model)
        {
            if (ModelState.IsValid)
            {
                TempData["EditSuccess"] = true;
                await _countryService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [Route("Delete-Country")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _countryService.GetById(id);
            if (item == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["DeleteSuccess"] = true;
                await _countryService.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}
