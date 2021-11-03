using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name Required")]
        public string FullName { get; set; }

        [Display(Name="Email Address")]
        [Required(ErrorMessage ="Email Address Required")]
        public string EmalAddress { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
