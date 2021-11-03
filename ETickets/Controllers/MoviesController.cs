using ETickets.Data;
using ETickets.Data.Services;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ETickets.Data.Static;

namespace ETickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n=>n.Cinema);
            return View(allMovies);
        }
        [AllowAnonymous]
        
        public async Task<IActionResult> Filter(String searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || 
                //n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name,searchString,StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(n.Description, searchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
                return View("Index", filteredResultNew);
            }
            return View("Index", allMovies);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var moiveDetails = await _service.GetMovieByIdAsync(id);
            return View(moiveDetails);
        }

        //Movie/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMoivesDropdowns();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas,"Id","Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName"); 
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            var movieDropdownsData = await _service.GetNewMoivesDropdowns();
            if (!ModelState.IsValid)
            {
                ViewBag.Cenimas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //Movie/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");
            var response = new NewMovieVM()
            {
                Id= movieDetails.Id,
                Name= movieDetails.Name,
                Description= movieDetails.Description,
                Price= movieDetails.Price,
                StartDate= movieDetails.StartDate,
                EndDate= movieDetails.EndDate,
                ImageURL =movieDetails.ImageURL,
                MovieCategory=movieDetails.MovieCategory,
                CinemaId= movieDetails.CinemaId,
                ProducerId= movieDetails.ProducerId,
                ActorIds= movieDetails.Actor_Movies.Select(n=>n.ActorId).ToList(),

            };

            var movieDropdownsData = await _service.GetNewMoivesDropdowns();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            var movieDropdownsData = await _service.GetNewMoivesDropdowns();
            if (!ModelState.IsValid)
            {
                ViewBag.Cenimas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

    }
}
