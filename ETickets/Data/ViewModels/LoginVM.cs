using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name="Email Address")]
        [Required(ErrorMessage ="Email Address Required")]
        public string EmalAddress { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
