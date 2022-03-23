using CinemaTickets.Data.Repository;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class LanguageService : EntityRepository<Language>, ILanguageService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LanguageService(CinemaTicketsContext context,
                                IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public override IQueryable<Language> Search(IQueryable<Language> language, string search)
        {
            return language.Where(m => m.LanguageName.Contains(search));
        }
        public async Task<Language> GetDetailsById(int id)
        {
            var model = await _context.Languages.FindAsync(id);
            if (model != null)
            {
                return model;
            }
            return null;
        }

        public async Task Update(Language model)
        {
            Language editItem = await _context.Languages.FindAsync(model.Id);
            editItem.LanguageName = model.LanguageName;

            _context.Languages.Update(editItem);
            await _context.SaveChangesAsync();
        }
        public async Task Create(Language model)
        {
            Language createItem = new()
            {
                LanguageName = model.LanguageName
            };

            await _context.Languages.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }

       
    }
}
