using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.CrewDetails;
using CinemaTickets.Data.Helper;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class CrewService : EntityRepository<Crew> , ICrewService
    {
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CrewService(CinemaTicketsContext context,
                           IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public override IQueryable<Crew> Search(IQueryable<Crew> crew, string search)
        {
            return crew.Where(a => a.CrewName.Contains(search) || a.Nationality.CountryName.Contains(search));
        }
        public async Task<CrewDetailsEditViewModel> GetDetailsById(int id)
        {
            var model = await _context.Crew.Where(crew => crew.Id == id)
                                         .Select(crew => new CrewDetailsEditViewModel
                                         {
                                                CrewId = crew.Id,
                                                CrewName = crew.CrewName,
                                                CrewBiography = crew.CrewBiography,
                                                CrewDateofBirth = crew.CrewDateofBirth,
                                                NationalityName = crew.Nationality.CountryName,
                                                CrewRoleName = crew.CrewRole.CrewRoleName,
                                                NationalityId = crew.NationalityId,
                                                CrewRoleId = crew.CrewRoleId,
                                                ExistPhoto = crew.CrewImageURL,
                                                ExistCrewGallery = crew.CrewGallary.Select(g => new Crew_Gallery()
                                                {
                                                    Id = g.Id,
                                                    ImageURL = g.ImageURL
                                                }).ToList()
                                         }).FirstOrDefaultAsync();
            if (model != null)
            {
                return model;
            }
            return null;
        }

        public async Task Update(CrewDetailsEditViewModel model, string folderPath)
        {
            Crew editItem = await _context.Crew.FindAsync(model.CrewId);
            editItem.CrewName = model.CrewName;
            editItem.CrewBiography = model.CrewBiography;
            editItem.CrewDateofBirth = model.CrewDateofBirth;
            editItem.NationalityId = model.NationalityId;
            editItem.CrewRoleId = model.CrewRoleId;
            await AddCoverPhoto(model, editItem, folderPath, model.ExistPhoto);
            await AddGallaryPhotos(model, editItem, folderPath);

            _context.Crew.Update(editItem);
            await _context.SaveChangesAsync();
        }
        public async Task Create(CrewDetailsCreateViewModel model, string folderPath)
        {
            Crew createItem = new()
            {
                Id = model.CrewId,
                CrewName = model.CrewName,
                CrewBiography = model.CrewBiography,
                CrewDateofBirth = model.CrewDateofBirth,
                NationalityId = model.NationalityId,
                CrewRoleId = model.CrewRoleId,
            };
            await AddCoverPhoto(model, createItem, folderPath);
            await AddGallaryPhotos(model, createItem, folderPath);

            await _context.Crew.AddAsync(createItem);
            await _context.SaveChangesAsync();
        }

        public PagedResult<Crew> GetDataBySearchInPages(int page, string search = "", int crewType = 0)
        {
            var crew = _context.Crew.ToList().AsQueryable();
            if (crew != null)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    if (crewType == 0)
                    {
                        return crew.Where(c => c.CrewName.Contains(search) ).GetPaged(page, 7);
                    }
                    return crew.Where(c => c.CrewName.Contains(search) && c.CrewRoleId == crewType ).GetPaged(page, 7);
                }
                else
                {
                    if (crewType == 0)
                    {
                        return crew.GetPaged(page, 7);
                    }
                    return crew.Where(c => c.CrewRoleId == crewType).GetPaged(page, 7);
                }
            }
            return null;
        }

        public async Task<IEnumerable<Crew>> GetAllByType(int crewType)
        {
            return await _context.Crew.Where(c=> c.CrewRoleId == crewType).ToListAsync();
        }

        // Hellper Function
        private async Task AddCoverPhoto(CrewDetailsCreateViewModel model, Crew Item, string folderPath, string ExistPhoto = null)
        {
            if (model.CoverPhoto != null)
            {
                if (ExistPhoto != null)
                {
                    string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "crews", ExistPhoto);
                    System.IO.File.Delete(FilePath);
                }
                Item.CrewImageURL = await UploadPhoto(model.CoverPhoto, folderPath);
            }
        }
        private async Task AddGallaryPhotos(CrewDetailsCreateViewModel model, Crew Item, string folderPath)
        {
            if (model.GallaryPhotos != null)
            {
                Item.CrewGallary = new List<Crew_Gallery>();
                foreach (var image in model.GallaryPhotos)
                {
                    Item.CrewGallary.Add(new Crew_Gallery()
                    {
                        CrewId = Item.Id,
                        ImageURL = await UploadPhoto(image, folderPath)
                    });
                }
            }
        }

        
    }
}
