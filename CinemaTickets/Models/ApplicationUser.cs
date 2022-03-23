using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CinemaTickets.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
