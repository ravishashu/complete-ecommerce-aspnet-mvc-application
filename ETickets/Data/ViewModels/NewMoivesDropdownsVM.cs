using ETickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Data.ViewModels
{
    public class NewMoivesDropdownsVM
    {
        public NewMoivesDropdownsVM()
        {
            Producers = new List<Producer>();
            Actors = new List<Actor>();
            Cinemas = new List<Cinema>();
        }

        public List<Producer> Producers { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Cinema> Cinemas { get; set; }
    }
}
