using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.BookingDetails;
using CinemaTickets.Data.ViewModels.Shows;
using CinemaTickets.Data.Helper;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class ShowService : EntityRepository<Show>, IShowService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ShowService(CinemaTicketsContext context,
                                IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public override  PagedResult<Show> GetDataBySearchInPages(int page, string search = "")
        {

            var entities = _context.Shows.Include(x => x.Movie)
                                          .Include(x=> x.Screen.Theater)
                                          .Include(x => x.Screen)
                                          .AsQueryable();

            if (entities != null)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return Search(entities, search).GetPaged(page, 10);
                }
                return entities.GetPaged(page, 10);
            }
            return null;
        }
        public override IQueryable<Show> Search(IQueryable<Show> show, string search)
        {  
            return show.Where(x => x.Movie.MovieName.Contains(search)  || x.Screen.ScreenName.Contains(search) || x.Screen.Theater.TheaterName.Contains(search));
        }
      
        public async Task<ShowEditViewModel> GetDetailsById(int id)
        {
            var model = await _context.Shows.Where(x => x.Id == id)
                                        .Select(show => new ShowEditViewModel
                                        {
                                             ShowId = show.Id,
                                             MovieId = show.MovieId,
                                             ScreenId = show.ScreenId,
                                             TheaterId = show.Screen.TheaterId,
                                             TimeId = show.Show_Time.Where(x=>x.ShowId == id && x.TimeId == x.Time.Id).Select(x=>x.Time.Id).ToList(),
                                             ShowStartDate = show.ShowStartDate,
                                             ShowEndDate = show.ShowEndDate,
                                        }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }

        public async Task Update(ShowEditViewModel model)
        {
            Show editItem = await _context.Shows.Include(x => x.Show_Time).FirstOrDefaultAsync(x => x.Id == model.ShowId);

            editItem.ShowStartDate = model.ShowStartDate;
            editItem.ShowEndDate = model.ShowEndDate;
            editItem.MovieId = model.MovieId;
            editItem.ScreenId = model.ScreenId;
            AddShowTime(model, editItem);

            _context.Shows.Update(editItem);
            await _context.SaveChangesAsync();
        }
        public async Task Create(ShowEditViewModel model)
        {
            Show createItem = new()
            {
                Id = model.ShowId,
                MovieId = model.MovieId,
                ScreenId = model.ScreenId,
                ShowStartDate = model.ShowStartDate,
                ShowEndDate = model.ShowEndDate, 
            };
            AddShowTime(model, createItem);
            await _context.Shows.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetShowId(BookingDetailsViewModel model)
        {
            return await _context.Shows.Where(x => x.ScreenId == model.ScreenId && x.MovieId == model.MovieId).Select(x => x.Id).FirstOrDefaultAsync();
        }

        // Hellper Function
        private void AddShowTime(ShowEditViewModel model, Show Item)
        {
            if (model.TimeId != null)
            {
                Item.Show_Time = new List<Show_Time>();
                foreach (var showTime in model.TimeId)
                {
                    Item.Show_Time.Add(new()
                    {
                        TimeId = showTime,
                        ShowId = Item.Id,
                    });
                }
            }
        }


    }
}
