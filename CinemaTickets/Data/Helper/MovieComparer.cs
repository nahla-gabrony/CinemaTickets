using CinemaTickets.Models;
using System.Collections.Generic;

namespace CinemaTickets.Data.Helper
{
    public class MovieComparer : IEqualityComparer<Movie>
    {
        public bool Equals(Movie x, Movie y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }

            return x.Id.Equals(y.Id);

        }

        public int GetHashCode(Movie obj)
        {
            if (obj == null)
            {
                return 0;
            }
            int IdHashCode = obj.Id.GetHashCode();
            return IdHashCode;
        }

      
    }
}
