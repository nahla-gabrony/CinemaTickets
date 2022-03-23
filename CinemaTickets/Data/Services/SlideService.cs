using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.Slide;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class SlideService : EntityRepository<Slide>, ISlideService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SlideService(CinemaTicketsContext context,
                            IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<SlideEditViewModel> GetDetailsById(int id)
        {
            var model = await _context.Slides.Where(slide => slide.Id == id)
                                         .Select(slide => new SlideEditViewModel
                                         {
                                             SlideId = slide.Id,
                                             SlideTitle = slide.SlideTitle,
                                             SlideDetails = slide.SlideDetails,
                                             ExistPhoto = slide.SlideImageURL,
                                             IsActive = slide.IsActive,
                                             MovieId = slide.MovieId
                                         }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }

        public async Task Update(SlideEditViewModel model, string folderPath)
        {

            Slide editItem = await _context.Slides.FindAsync(model.SlideId);
            editItem.SlideTitle = model.SlideTitle;
            editItem.SlideDetails = model.SlideDetails;
            editItem.IsActive = model.IsActive;
            editItem.MovieId = model.MovieId;
            await AddCoverPhoto(model, editItem, folderPath, model.ExistPhoto);

            _context.Slides.Update(editItem);
            await _context.SaveChangesAsync();
        }
        public async Task Create(SlideCreateViewModel model, string folderPath)
        {
            Slide createItem = new()
            {
                SlideTitle = model.SlideTitle,
                SlideDetails = model.SlideDetails,
                IsActive = model.IsActive,
                MovieId = model.MovieId
            };
            await AddCoverPhoto(model, createItem, folderPath);

            await _context.Slides.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }

        public override IQueryable<Slide> Search(IQueryable<Slide> slide, string search)
        {
            return slide.Where(m => m.SlideTitle.Contains(search));
        }

        public int CountAllActive()
        {
            return _context.Slides.Where(s=> s.IsActive== true).Count();
        }

        // Hellper Function
        private async Task AddCoverPhoto(SlideCreateViewModel model, Slide Item, string folderPath, string ExistPhoto = null)
        {
            if (model.CoverPhoto != null)
            {
                if (ExistPhoto != null)
                {
                    string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "slides", ExistPhoto);
                    System.IO.File.Delete(FilePath);
                }
                Item.SlideImageURL = await UploadPhoto(model.CoverPhoto, folderPath);
            }
        }
     
    }
}
