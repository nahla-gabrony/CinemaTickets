using CinemaTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
    public class TheatersController : Controller
    {
        private readonly ITheaterService _theaterService;

        public TheatersController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        [Route("Theaters")]
        public async Task<ViewResult> Index()
        {

            var data = await _theaterService.GetTheaterBySearch();
            return View(data);
        }

        [Route("Theaters")]
        [HttpGet]
        public async Task<ViewResult> Index(string search)
        {
            ViewData["SearchString"] = search;
            var data = await  _theaterService.GetTheaterBySearch(search);
            return View(data);
        }

        [Route("Theater-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _theaterService.GetDetailsForUserById(id);
            if (data == null)
            {
                ViewBag.Message = "Oops.This Theater doesn't exist.";
                return View("NotFound");
            }
            return View(data);
        }
    }
}
