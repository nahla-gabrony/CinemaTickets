using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels.BookingDetails;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITheaterService _theaterService;
        private readonly IShowService _showService;
        private readonly IScreenService _screenService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public BookingController(IBookingService bookingService,
                                  ITheaterService theaterService,
                                  IShowService showService,
                                  IScreenService screenService,
                                  SignInManager<ApplicationUser> signInManager)
        {
            _bookingService = bookingService;
            _theaterService = theaterService;
           _showService = showService;
            _screenService = screenService;
           _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
     
        [HttpGet]
        [Route("Booking/{id:int:min(1)}")]
        public async Task<ViewResult> BookingDetails(int id)
        {  
            var data = await _bookingService.GetTheatersDetailsById(id);   
            if (data == null)
            {
                ViewBag.Message = "Oops.This movie is temporarily unavailable for booking or doesn't exist.";
                return View("NotFound");
            }
            ViewBag.Theaters = data.Theaters.Distinct();
            return View(data);
        }

        [HttpPost]
        [Route("Booking/{id:int:min(1)}")]
        public ActionResult BookingDetails(BookingDetailsViewModel model)
        {
            HttpContext.Session.SetString("BookingDetails", JsonConvert.SerializeObject(model));
            return RedirectToAction("BookingSeats");
        }


        [HttpGet]
        [Route("Booking-Seats")]
        public async Task<ViewResult> BookingSeats()
        {
            if (HttpContext.Session.GetString("BookingDetails") != null)
            {
                BookingDetailsViewModel BookingDetails = JsonConvert.DeserializeObject<BookingDetailsViewModel>(HttpContext.Session.GetString("BookingDetails"));
                BookingTicketsViewModel BookingTicketModel = await _bookingService.GetBookingSeatsDetails(BookingDetails);
                ViewBag.ReservedTickets = BookingTicketModel.ReservedTickets;
                HttpContext.Session.SetString("BookingSeats", JsonConvert.SerializeObject(BookingTicketModel));
                var screenPage =  "BookingSeats-" + BookingTicketModel.TheaterId;
                 return View(screenPage, BookingTicketModel);
                
            }

            return View("NotFound");
        }

        [HttpPost]
        [Route("Booking-Seats")]
        public ActionResult BookingSeats(BookingTicketsViewModel model)
        {
            if (HttpContext.Session.GetString("BookingSeats") != null)
            {
                BookingTicketsViewModel BookingSeats = JsonConvert.DeserializeObject<BookingTicketsViewModel>(HttpContext.Session.GetString("BookingSeats"));
                var TicketsList = model.TicketsList;
                model = BookingSeats;
                model.TicketsList = TicketsList;
            }
            //Add Session
            HttpContext.Session.SetString("BookingSeats", JsonConvert.SerializeObject(model));
            return RedirectToAction("Tickets");
        }

        [Authorize]
        [Route("Tickets")]
        public ViewResult Tickets()
        {
            if (HttpContext.Session.GetString("BookingSeats") != null)
            {
                BookingTicketsViewModel BookingSeats = JsonConvert.DeserializeObject<BookingTicketsViewModel>(HttpContext.Session.GetString("BookingSeats"));
                int count = BookingSeats.TicketsList.Count();
                BookingSeats.TicketsCount = count;
                TimeSpan checkTime = new TimeSpan(1, 30, 00);
                if (BookingSeats.ShowTime > checkTime)
                {
                    BookingSeats.TicketsPrice = count * 100;
                    BookingSeats.TicketPrice = 100;
                }
                else
                {
                    BookingSeats.TicketsPrice = count * 60;
                    BookingSeats.TicketPrice = 60;
                }
                HttpContext.Session.SetString("BookingSeats", JsonConvert.SerializeObject(BookingSeats));
                return View(BookingSeats);
            }
            return View("NotFound");
        }

        [Authorize]
        [Route("Checkout")]
        public async Task<IActionResult> Checkout()
        {
            BookingTicketsViewModel model = null;
            if (HttpContext.Session.GetString("BookingSeats") != null)
            {
                BookingTicketsViewModel BookingSeats = JsonConvert.DeserializeObject<BookingTicketsViewModel>(HttpContext.Session.GetString("BookingSeats"));
                model = BookingSeats;
                await _bookingService.Create(model);
                return View(model);
            }
            return View("NotFound");
        }

        // Json Function
        public JsonResult GetTicketsDetails(string[] ticketsList)
        {
            TempData["mydata"] = ticketsList.Count();
            return Json(ticketsList);
        }

        public async Task<JsonResult> GetDate(int movieId)
        {
            var data = await _bookingService.GetDateDetailsById(movieId);
            DateTime endShowDate = data.ShowEndDate.Date;
            DateTime startDate = DateTime.Now.Date;

            var dateList = new List<SelectListItem>();
            for (int i = 0; i < 5; i++)
            {
                if(startDate <= endShowDate)
                {
                    dateList.Add(new SelectListItem
                    {
                        Text = startDate.ToString("dddd, dd MMMM yyyy"),
                        Value = startDate.ToString()
                    });
                    startDate = startDate.AddDays(1);
                }
                else
                {
                    break;
                }
            }
       
            dateList.Insert(0, new SelectListItem() { Value = "null", Text = "Choose Date" });
            return Json(dateList);
        }
        public async Task<JsonResult> GetTime(int movieId, DateTime dateTime,int theaterId)
        {
            var data = await _bookingService.GetTimeDetailsById(movieId, theaterId);
            var ShowTimes = data.Times.Select(x=>x.MovieTime).Distinct().OrderBy(x=>x.TotalSeconds).ToList();
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            List<SelectListItem> timeList = new List<SelectListItem>();
            foreach (var time in ShowTimes)
            {
                DateTime Newtime = DateTime.Today.Add(time);
                if (dateTime.Date != DateTime.Now.Date || currentTime < time)
                {
                    timeList.Add(new SelectListItem
                    {
                        Text = Newtime.ToString("hh:mm tt"),
                        Value = time.ToString()
                    });
                }
            }

            timeList.Insert(0, new SelectListItem() { Value = "null", Text = "Choose Show Time" });
            return Json(timeList);

        }
        public async Task<JsonResult> GetScreenByTheaterId(int theaterId, int movieId, DateTime dateTime)
        {
            var data = await _bookingService.GetScreenDetailsById(movieId, theaterId, dateTime);
            var screenData= data.Screens.ToList();

            var ScreenList = new SelectList(screenData, "Id", "ScreenName").ToList<SelectListItem>();
            ScreenList.Insert(0, new SelectListItem() { Value = "null", Text = "Choose Screen" });

            return Json(ScreenList);
        }

     
    }
}
