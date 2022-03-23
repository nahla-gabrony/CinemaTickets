using CinemaTickets.Data.Repository;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;

namespace CinemaTickets.Data.Services
{
    public class TimeService : EntityRepository<Time>, ITimeService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TimeService(CinemaTicketsContext context,
                                IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public override IQueryable<Time> Search(IQueryable<Time> entity, string search)
        {
            throw new NotImplementedException();
        }


    }
}
