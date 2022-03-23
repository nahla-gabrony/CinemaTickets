using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.Theaters;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class TheaterService : EntityRepository<Theater>, ITheaterService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TheaterService(CinemaTicketsContext context, 
                              IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public override IQueryable<Theater> Search(IQueryable<Theater> theater, string search)
        {
            return theater.Where(x => x.TheaterName.Contains(search));
        }
        public async Task<IEnumerable<TheaterViewModel>> GetTheaterBySearch(string search = "")
        {
            var item = _context.Theaters.Select(theater => new TheaterViewModel
                                                        {
                                                            TheaterId = theater.Id,
                                                            TheaterName = theater.TheaterName,
                                                            TheaterDetails = theater.TheaterDetails,
                                                            TheaterLocation = theater.TheaterLocation,
                                                            ExistPhoto = theater.TheaterImageURL,
                                                            Movies = theater.Screens.SelectMany(x => x.Show).Where(x => x.ShowStartDate < DateTime.Today && x.ShowEndDate > DateTime.Today).Select(x => x.Movie).ToList()
            });
            if (item != null)
            {
                if (!string.IsNullOrEmpty(search))
                {
                     return await  SearchTheater(item, search).ToListAsync();
                }
                return await item.ToListAsync();
            }
            return null;
        }
     
        public async Task<TheaterEditViewModel> GetDetailsById(int id)
        {
            var model = await _context.Theaters.Where(theater => theater.Id == id)
                                                 .Select(theater => new TheaterEditViewModel
                                                 {
                                                     TheaterId = theater.Id,
                                                     TheaterName = theater.TheaterName,
                                                     TheaterDetails = theater.TheaterDetails,
                                                     TheaterLocation = theater.TheaterLocation,
                                                     ExistPhoto = theater.TheaterImageURL,
                                                 }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }
        public async Task<TheaterViewModel> GetDetailsForUserById(int id)
        {
            var model = await _context.Theaters.Where(theater => theater.Id == id)
                                                 .Select(theater => new TheaterViewModel
                                                 {
                                                     TheaterId = theater.Id,
                                                     TheaterName = theater.TheaterName,
                                                     TheaterDetails = theater.TheaterDetails,
                                                     TheaterLocation = theater.TheaterLocation,
                                                     ExistPhoto = theater.TheaterImageURL,
                                                     Movies = theater.Screens.SelectMany(x => x.Show).Where(x => x.ShowStartDate < DateTime.Today && x.ShowEndDate > DateTime.Today).Select(x => x.Movie).ToList()
                                                 }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }
        public async Task Update(TheaterEditViewModel model , string folderPath)
        {
            Theater editItem = await _context.Theaters.FindAsync(model.TheaterId);
            editItem.TheaterName = model.TheaterName;
            editItem.TheaterDetails = model.TheaterDetails;
            editItem.TheaterLocation = model.TheaterLocation;
            await AddCoverPhoto(model, editItem, folderPath, model.ExistPhoto);

            _context.Theaters.Update(editItem);
            await _context.SaveChangesAsync();
        }
        public async Task Create(TheaterCreateViewModel model, string folderPath)
        {
            Theater createItem = new()
            {
                TheaterName = model.TheaterName,
                TheaterDetails = model.TheaterDetails,
                TheaterLocation = model.TheaterLocation
            };
            await AddCoverPhoto(model, createItem, folderPath);
            await _context.Theaters.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }
     
     
        public async Task<string> GetTheaterName(int theaterId)
        {
            return await _context.Theaters.Where(x => x.Id == theaterId).Select(x => x.TheaterName).FirstOrDefaultAsync();
        } 
     
    
        // Hellper Function

        private async Task AddCoverPhoto(TheaterCreateViewModel model, Theater Item, string folderPath, string ExistPhoto = null)
        {
            if (model.CoverPhoto != null)
            {
                if (ExistPhoto != null)
                {
                    string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "theater", ExistPhoto);
                    System.IO.File.Delete(FilePath);
                }
                Item.TheaterImageURL = await UploadPhoto(model.CoverPhoto, folderPath);
            }
        }

        private IQueryable<TheaterViewModel> SearchTheater(IQueryable<TheaterViewModel> theater, string search)
        {
            return theater.Where(x => x.TheaterName.Contains(search));
        }

    }
}
