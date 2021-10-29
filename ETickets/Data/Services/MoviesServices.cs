using ETickets.Data.Base;
using ETickets.Data.ViewModels;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Data.Services
{
    public class MoviesServices : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesServices(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId,
                StartDate=data.StartDate,
                EndDate=data.EndDate,
                MovieCategory=data.MovieCategory
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Moive Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId=newMovie.Id,
                    ActorId=actorId,
                };

                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies)
                .ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id == id);
            return movieDetails;
        }

        public async Task<NewMoivesDropdownsVM> GetNewMoivesDropdowns()
        {
            var response = new NewMoivesDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
    }
}
