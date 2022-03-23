using CinemaTickets.Data.Repository;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;

namespace CinemaTickets.Data.Services
{
    public class CrewRoleService : EntityRepository<Crew_Role>, ICrewRoleService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CrewRoleService(CinemaTicketsContext context,
                                IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public override IQueryable<Crew_Role> Search(IQueryable<Crew_Role> entity, string search)
        {
            throw new NotImplementedException();
        }


    }
}
