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

namespace ETickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n=>n.Cinema);
            return View(allMovies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var moiveDetails = await _service.GetMovieByIdAsync(id);
            return View(moiveDetails);
        }

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

    }
}
