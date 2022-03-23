using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.BookingDetails;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class BookingService : EntityRepository<Ticket> , IBookingService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITheaterService _theaterService;
        private readonly IShowService _showService;
        private readonly IScreenService _screenService;
        private readonly IUserService _userService;

        public BookingService(CinemaTicketsContext context,
                                IWebHostEnvironment webHostEnvironment,
                                ITheaterService theaterService,
                                IShowService showService,
                                IScreenService screenService,
                                IUserService userService ) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _theaterService = theaterService;
            _showService = showService;
            _screenService = screenService;
            _userService = userService;
        }
        public override IQueryable<Ticket> Search(IQueryable<Ticket> movies, string search)
        {
            return movies.Where(x => x.Show.Screen.ScreenName.Contains(search));
        }
         public async Task<BookingDetailsViewModel> GetTheatersDetailsById(int id)
           {
            var model = await _context.Movies.Where(x => x.Id == id && x.Show.Any(x => x.ShowStartDate < DateTime.Today && x.ShowEndDate > DateTime.Today))
                                                .Select(movie => new BookingDetailsViewModel
                                                {
                                                    MovieId = movie.Id,
                                                    MovieName = movie.MovieName,
                                                    ExistPhoto = movie.MovieImageURL,
                                                    Theaters = movie.Show.Select(x => x.Screen).Select(x => x.Theater).ToList(),
                                                }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }
        public async Task<BookingDetailsViewModel> GetDateDetailsById(int id)
        {
            var model = await _context.Movies.Where(x => x.Id == id)
                                                .Select(movie => new BookingDetailsViewModel
                                                {
                                                    MovieId = movie.Id,
                                                    ShowEndDate = movie.Show.Select(x => x.ShowEndDate).FirstOrDefault(),
                                                }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }
        public async Task<BookingDetailsViewModel> GetTimeDetailsById(int id,int theaterId)
        {
            var model = await _context.Movies.Where(x => x.Id == id)
                                                .Select(movie => new BookingDetailsViewModel
                                                {
                                                    Times = movie.Show.Where(x=>x.Screen.TheaterId == theaterId).SelectMany(x=>x.Show_Time).Select(x => x.Time).ToList(),
                                                }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }
        public async Task<BookingDetailsViewModel> GetScreenDetailsById(int id , int theaterId , DateTime dateTime)
        {
            var model = await _context.Movies.Where(x => x.Id == id )
                                                .Select(movie => new BookingDetailsViewModel
                                                {
                                                    Screens = movie.Show.Select(x => x.Screen).Where(x=>x.TheaterId == theaterId && x.Show.Any(s=>s.Show_Time.Any(t=>t.Time.MovieTime == dateTime.TimeOfDay))).ToList(),
                                                }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }
        public async Task<BookingTicketsViewModel> GetBookingSeatsDetails(BookingDetailsViewModel model)
        {
            var showId = await _showService.GetShowId(model);
            BookingTicketsViewModel BookingTicketModel = new BookingTicketsViewModel()
            {
                MovieId = model.MovieId,
                ScreenId = model.ScreenId,
                TheaterId = model.TheaterId,
                MovieName = model.MovieName,
                TheaterName = await _theaterService.GetTheaterName(model.TheaterId),
                ScreenName = await _screenService.GetScreenName(model.ScreenId),
                ShowDateString = model.ShowDate.ToString("dd/MM/yyyy"),
                ShowTimeString = DateTime.Today.Add(model.ShowTime).ToString("hh:mm tt"),
                ShowDate = model.ShowDate,
                ShowTime = model.ShowTime,
                ReservedTickets = await GetReservedTickets(model, showId)
            };

            return BookingTicketModel;
        }
        public async Task Create(BookingTicketsViewModel model)
        {
            foreach (var ticket in model.TicketsList)
            {
                Ticket createItem = new()
                {
                    TicketPrice = model.TicketPrice,
                    SeatNumber = ticket,
                    ShowDate = model.ShowDate,
                    ShowTime = model.ShowTime, 
                    ShowId = await _showService.GetShowId(model),
                    UserId = _userService.GetUserId(),
                };

                await _context.Tickets.AddAsync(createItem);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<String>> GetReservedTickets(BookingDetailsViewModel model, int showId)
        { 
             return await _context.Tickets.Where(x => x.ShowId == showId && x.ShowDate == model.ShowDate && x.ShowTime == model.ShowTime).Select(x => x.SeatNumber).ToListAsync();
        }
        public async Task<int> TodaySolidTickets()
        {
            return await _context.Tickets.Where(x=>x.ShowDate == DateTime.Today).CountAsync();
        }
        public async Task<int> TodayTicketsProfit()
        {
            return await _context.Tickets.Where(x => x.ShowDate == DateTime.Today).SumAsync(x=>x.TicketPrice);
        }
        public async Task<int> MonthTicketsProfit(int theaterId, int movieId)
        {
            var year = DateTime.Today.Year;
            var month = DateTime.Today.Month;
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            if(theaterId != 0)
            {
                return await _context.Tickets.Where(x => x.ShowDate >= startDate && x.ShowDate <= endDate && x.Show.Screen.TheaterId == theaterId).SumAsync(x => x.TicketPrice);
            }
            else if (movieId != 0)
            {
                return await _context.Tickets.Where(x => x.ShowDate >= startDate && x.ShowDate <= endDate && x.Show.MovieId == movieId).SumAsync(x => x.TicketPrice);
            }
            return await _context.Tickets.Where(x => x.ShowDate >= startDate && x.ShowDate <= endDate).SumAsync(x => x.TicketPrice);
        }
        public async Task<List<TicketsProfitsViewModel>> TheaterProfits()
        {
            var Theaters = await _context.Theaters.ToListAsync();
            List<TicketsProfitsViewModel> model = new List<TicketsProfitsViewModel>();
            foreach (var theater in Theaters)
            {
                TicketsProfitsViewModel item = new TicketsProfitsViewModel
                {
                    TheaterId = theater.Id,
                    TheaterName = theater.TheaterName,
                    DailyTickets = await _context.Tickets.Where(x => x.ShowDate == DateTime.Today && x.Show.Screen.TheaterId == theater.Id).CountAsync(),
                    DailyProfit = await _context.Tickets.Where(x => x.ShowDate == DateTime.Today && x.Show.Screen.TheaterId == theater.Id).SumAsync(x => x.TicketPrice),
                    MonthlyProfit = await MonthTicketsProfit(theater.Id,0),
                };
                model.Add(item);
            };
            return model;
        }

        public async Task<List<TicketsProfitsViewModel>> MovieProfits()
        {
            var Movies = await _context.Movies.ToListAsync();
            List<TicketsProfitsViewModel> model = new List<TicketsProfitsViewModel>();
            foreach (var movie in Movies)
            {
                TicketsProfitsViewModel item = new TicketsProfitsViewModel
                {
                    MovieId = movie.Id,
                    MovieName = movie.MovieName,
                    DailyTickets = await _context.Tickets.Where(x => x.ShowDate == DateTime.Today && x.Show.MovieId == movie.Id).CountAsync(),
                    DailyProfit = await _context.Tickets.Where(x => x.ShowDate == DateTime.Today && x.Show.MovieId == movie.Id).SumAsync(x => x.TicketPrice),
                    MonthlyProfit = await MonthTicketsProfit(0,movie.Id),
                };
                model.Add(item);
            };
            return model;
        }

    }
}
