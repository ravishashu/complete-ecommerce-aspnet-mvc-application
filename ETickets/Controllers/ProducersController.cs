using ETickets.Data;
using ETickets.Data.Services;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ETickets.Data.Static;

namespace ETickets.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
   
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //Get Producers/Create()

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("FullName", "ProfilePictureURL", "Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);

            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get Producers/Edit()

        public async Task<IActionResult> EditAsync(int Id)
        {

            var producerDetails = await _service.GetByIdAsync(Id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            if (id==producer.Id)
            {
                await _service.UpdateAsync(id, producer);
            }
            
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }


}
