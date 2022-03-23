using CinemaTickets.Data.Repository;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class GenreService : EntityRepository<Genre>, IGenreService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GenreService(CinemaTicketsContext context,
                                IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public override IQueryable<Genre> Search(IQueryable<Genre> genre, string search)
        {
            return genre.Where(g => g.GenreName.Contains(search));
        }
        public async Task<Genre> GetDetailsById(int id)
        {
            var model = await _context.Genres.FindAsync(id);
            if (model != null)
            {
                return model;
            }
            return null;
        }

        public async Task Update(Genre model)
        {
            Genre editItem = await _context.Genres.FindAsync(model.Id);
            editItem.GenreName = model.GenreName;

            _context.Genres.Update(editItem);
            await _context.SaveChangesAsync();
        }
        public async Task Create(Genre model)
        {
            Genre createItem = model;

            await _context.Genres.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }

     
    }
}
