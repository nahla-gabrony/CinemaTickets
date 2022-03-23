using CinemaTickets.Data.Repository;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class CountryService : EntityRepository<Country>, ICountryService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CountryService(CinemaTicketsContext context,
                                IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public override IQueryable<Country> Search(IQueryable<Country> country, string search)
        {
            return country.Where(c => c.CountryName.Contains(search));
        }
        public async Task<Country> GetDetailsById(int id)
        {
            var model = await _context.Countries.FindAsync(id);
            if (model != null)
            {
                return model;
            }
            return null;
        }

        public async Task Update(Country model)
        {
            Country editItem = await _context.Countries.FindAsync(model.Id);
            editItem.CountryName = model.CountryName;


            _context.Countries.Update(editItem);
            await _context.SaveChangesAsync();
        }
        public async Task Create(Country model)
        {
            Country createItem = model;

            await _context.Countries.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }

  
    }
}
