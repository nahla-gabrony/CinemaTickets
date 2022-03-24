using CinemaTickets.Data.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Repository
{
    public abstract class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        DbSet<T> _dbSet;
        private CinemaTicketsContext context;
        private readonly CinemaTicketsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EntityRepository(CinemaTicketsContext context,
                                IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _dbSet = context.Set<T>();
        }

    
        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
     
        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Delete(int id)
        {
            var Entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(Entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetDataBySearch(string search = "")
        {
            var entities = _dbSet.AsNoTracking();
            if (entities != null)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return await Search(entities, search).ToListAsync();
                }
                return await entities.ToListAsync();
            }
            return null;
        }
        public virtual PagedResult<T> GetDataBySearchInPages(int page, string search = "")
        {
            var entities = _dbSet.AsNoTracking();
            if (entities != null)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return Search(entities, search).GetPaged(page, 13);
                }
                return entities.GetPaged(page, 13);
            }
            return null;
        }


        // Abstract Function
        public abstract IQueryable<T> Search(IQueryable<T> entity, string search);


        // Hellper Function
        public async Task<string> UploadPhoto(IFormFile imgFile, string folderPath)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + imgFile.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await imgFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "../" + folderPath;
        }




    }
}
