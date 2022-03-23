using CinemaTickets.Data.Repository;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class ScreenService : EntityRepository<Screen>, IScreenService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ScreenService(CinemaTicketsContext context,
                            IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
    public override IQueryable<Screen> Search(IQueryable<Screen> screen, string search)
        {
            return screen.Where(c => c.ScreenName.Contains(search));
        }
        public async Task<Screen> GetDetailsById(int id)
        {
            var model = await _context.Screens.FindAsync(id);
            if (model != null)
            {
                return model;
            }
            return null;
        }

        public async Task Update(Screen model)
        {
            Screen editItem = await _context.Screens.FindAsync(model.Id);
            editItem.ScreenName = model.ScreenName;
            editItem.TheaterId = model.TheaterId;


            _context.Screens.Update(editItem);
            await _context.SaveChangesAsync();
        }
        public async Task Create(Screen model)
        {
            Screen createItem = model;

            await _context.Screens.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Screen>> GetScreenByTheater(int theaterId)
        {
            return await _context.Screens.Where(x => x.Theater.Id == theaterId).ToListAsync();
        }
        public async Task<string> GetScreenName(int screenId)
        {
            var result = await _context.Screens.Where(x => x.Id == screenId).Select(x => x.ScreenName).FirstOrDefaultAsync();
            return result;
        }
    

    }
}
