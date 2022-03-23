using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Repository
{
    public interface IEntityRepository<T> where T : class
    {
        Task<int> Count();
         Task<IEnumerable<T>> GetAll();
         Task<T> GetById(int id);
         Task Delete(int id);
         
        Task<IEnumerable<T>> GetDataBySearch(string search = "");
         PagedResult<T> GetDataBySearchInPages(int page, string search = "");
    }
}
