using ETickets.Data;
using ETickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Models
{
    public class NewMovieVM
    {
        [Required(ErrorMessage ="Name is required")]
        [Display(Name ="Movie Name")]
        public string Name { get; set; }
        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Movie is Description")]
        public string Description { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Poster URL")]
        [Required(ErrorMessage = "Poster URL required")]
        public string ImageURL { get; set; }
        [Display(Name = "StartDate")]
        [Required(ErrorMessage = "StartDate required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "EndDate")]
        [Required(ErrorMessage = "EndDate required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select  Category")]
        [Required(ErrorMessage = "Movie Category is required")]
        public MovieCategory MovieCategory { get; set; }


        [Display(Name = "Select  Atcor(s)")]
        [Required(ErrorMessage = "Movie Atcor(s) is required")]

        public List<int> ActorIds { get; set; }



        [Display(Name = "Select  Cinema")]
        [Required(ErrorMessage = "Movie Cinema is required")]
        public int CinemaId { get; set; }


        [Display(Name = "Select  Producer")]
        [Required(ErrorMessage = "Movie Producer is required")]


        public int ProducerId { get; set; }

    }
}
