using CinemaTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
    public class CrewController : Controller
    {
        private readonly ICrewService _crewService;

        public CrewController(ICrewService crewService)
        {
            _crewService = crewService;
        }


        [Route("Crew-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _crewService.GetDetailsById(id);
            if (data == null)
            {
                ViewBag.Message = "Oops.The crew member does not exist.";
                return View("NotFound");
            }
            return View(data);
        }
    }
}
