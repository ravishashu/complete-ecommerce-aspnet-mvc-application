using ETickets.Data.Base;
using ETickets.Data.ViewModels;
using ETickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Data.Services
{
    public interface IMoviesService: IEntityBaseRepository<Movie>
    {

        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMoivesDropdownsVM> GetNewMoivesDropdowns();

        Task AddNewMovieAsync(NewMovieVM data);
    }
}
