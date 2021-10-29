using ETickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Cinema Logo")]
        [Required(ErrorMessage ="Cinema Logo is required")]
        public string Logo{ get; set; }
        [Required(ErrorMessage = "Cinema Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Desciption")]
        [Required(ErrorMessage = "Cinema Description is required")]

        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
