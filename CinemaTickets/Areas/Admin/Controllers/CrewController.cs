using CinemaTickets.Data;
using CinemaTickets.Data.Repository;
using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels.CrewDetails;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Areas.Admin.Controllers
{
    [Authorize(Policy  = "AdminManage")]
    [Route("admin")]
    [Area("admin")]
    public class CrewController : Controller
    {
        private readonly ICrewService _crewService;
        private readonly ICountryService _countryService;
        private readonly ICrewRoleService _crewRoleService;
        private readonly CinemaTicketsContext _context;

        public CrewController(ICrewService crewService ,
                             ICountryService countryService,
                             ICrewRoleService crewRoleService,
                             CinemaTicketsContext context)
        {
            _crewService = crewService;
            _countryService = countryService;
           _crewRoleService = crewRoleService;
            _context = context;
        }

        [Route("Crew-Index")]
        public ViewResult Index(int page =1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var crew = _crewService.GetDataBySearchInPages(page);
            return View(crew);
        }

        [Route("Crew-Index")]
        [HttpPost]
        public ViewResult Index(string search, int crewType ,int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewData["SearchString"] = search;
            PagedResult<Crew> crew = null;
            if (crewType == 1)
            {
                crew = _crewService.GetDataBySearchInPages(page,search,1);
            }
            else if (crewType == 2)
            {
                crew = _crewService.GetDataBySearchInPages(page, search,2);
            }
            else if (crewType == 3)
            {
                crew = _crewService.GetDataBySearchInPages(page, search ,3);
            }
            else
            {
                crew = _crewService.GetDataBySearchInPages(page, search);
            }
            return View(crew);
        }

        [Route("Crew-Create")]
        public async Task<ViewResult> Create()
        {
            var model = new CrewDetailsCreateViewModel();
            await GetSelectList();
            return View(model);
        }

        [Route("Crew-Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CrewDetailsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.IsSuccess = true;
                await _crewService.Create(model, "images/crews/");
                ModelState.Clear();
            }
            await GetSelectList();
            return View(model);
        }

        [Route("Crew-Details/{id:int:min(1)}")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _crewService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [Route("Crew-Edit/{id:int:min(1)}")]
        public async Task<ViewResult> Edit(int id)
        {
            var data = await _crewService.GetDetailsById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            await GetSelectList();
            return View(data);
        }

        [HttpPost]
        [Route("Crew-Edit/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(CrewDetailsEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["EditSuccess"] = true;
                await _crewService.Update(model, "images/crews/");
                return RedirectToAction("Index");
            }
            await GetSelectList();
            return View(model);
        }

        [Route("Delete-Crew")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _crewService.GetById(id);
            if (item == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["DeleteSuccess"] = true;
                await _crewService.Delete(id);
                return RedirectToAction("Index");
            }
        }
        private async Task GetSelectList()
        {
            ViewBag.Countries = await _countryService.GetAll();
           // ViewBag.CrewRoles = _context.Crews_Roles.ToList();
            ViewBag.CrewRoles = await _crewRoleService.GetAll();

        }

    }
}
