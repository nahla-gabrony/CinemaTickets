using System.Collections.Generic;

namespace CinemaTickets.Data.Repository
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; } = new List<T>();
       
    }
}
