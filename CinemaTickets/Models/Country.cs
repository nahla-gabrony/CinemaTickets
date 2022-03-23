using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Country Name")]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

    }
}
