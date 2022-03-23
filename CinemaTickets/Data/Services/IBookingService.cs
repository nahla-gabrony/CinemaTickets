using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.BookingDetails;
using CinemaTickets.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface IBookingService : IEntityRepository<Ticket>
    {

        Task<BookingDetailsViewModel> GetTheatersDetailsById(int id);
        Task<BookingDetailsViewModel> GetDateDetailsById(int id);
        Task<BookingDetailsViewModel> GetTimeDetailsById(int id, int theaterId);
        Task<BookingDetailsViewModel> GetScreenDetailsById(int id, int theaterId, DateTime dateTime);
        Task<BookingTicketsViewModel> GetBookingSeatsDetails(BookingDetailsViewModel model);
        Task Create(BookingTicketsViewModel model);

        Task<int> TodaySolidTickets();
        Task<int> TodayTicketsProfit();
        Task<int> MonthTicketsProfit(int theaterId, int movieId);
        Task<List<TicketsProfitsViewModel>> TheaterProfits();
        Task<List<TicketsProfitsViewModel>> MovieProfits();

    }
}
