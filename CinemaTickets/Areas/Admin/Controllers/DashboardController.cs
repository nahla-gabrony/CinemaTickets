using CinemaTickets.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminManage")]
    [Route("admin")]
    [Area("admin")]
    public class DashboardController : Controller
    {
       
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly ITheaterService _theaterService;
        private readonly IMovieService _movieService;
        private readonly IBookingService _bookingService;

        public DashboardController(IRoleService roleService,
                                   IUserService userService,
                                   ITheaterService theaterService,
                                   IMovieService movieService,
                                   IBookingService bookingService)
        {
            _roleService = roleService;
            _userService = userService;
            _theaterService = theaterService;
            _movieService = movieService;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            dynamic Model = new ExpandoObject();
            Model.UsersNumber = _userService.Count();
            Model.RolesNumber = _roleService.Count();
            Model.TheatersNumber =await _theaterService.Count();
            Model.CurrentMoviesNumber =  _movieService.GetMovies("now").Result.Count();
            Model.ComingtMoviesNumber = _movieService.GetMovies("soon").Result.Count();
            Model.TodaySolidTickets = await _bookingService.TodaySolidTickets();
            Model.TodayTicketsProfit = await _bookingService.TodayTicketsProfit();
            Model.TicketsProfit = await _bookingService.MonthTicketsProfit(0,0);
            Model.TheatersProfits = await _bookingService.TheaterProfits();
            Model.MoviesProfits = await _bookingService.MovieProfits();
       
            return View(Model);
        }
    }
}
