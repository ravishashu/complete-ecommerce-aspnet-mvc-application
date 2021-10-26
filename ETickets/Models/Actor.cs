using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Profile Picture")]
        [Required (ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage =" Full name shoud be between 3 and 50 char")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
   
        public string Bio { get; set; }

        //Relationship

        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
