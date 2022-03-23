using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Models
{
    public class Crew
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Name")]
        [Display(Name = "Name")]
        public string CrewName { get; set; }

        [Required(ErrorMessage = "Please Enter the Biography")]
        [Display(Name = "Biography")]
        public string CrewBiography { get; set; }

        public string CrewImageURL { get; set; }


        [Required(ErrorMessage = "Please Enter the Date of Birth")]
        [Display(Name = "Date of Birth")]
        [Column(TypeName = "date")]
        public DateTime CrewDateofBirth { get; set; }

        //Relationship
        [Display(Name = "Nationality")]
        public int? NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public Country Nationality { get; set; }

        [Display(Name = "Crew Role")]
        public int? CrewRoleId { get; set; }
        [ForeignKey("CrewRoleId")]
        public Crew_Role CrewRole { get; set; }

        public ICollection<Crew_Movie> Crew_Movies { get; set; }
        public ICollection<Crew_Gallery> CrewGallary { get; set; }

    }
}
