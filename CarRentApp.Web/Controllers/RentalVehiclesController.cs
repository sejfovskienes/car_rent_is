using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentApp.Domain.Models;
using CarRentApp.Repository;
using CarRentApp.Service.Interface;

namespace CarRentApp.Web.Controllers
{
    public class RentalVehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRentalVehicleService _rentalVehicleService;

        public RentalVehiclesController(ApplicationDbContext context, IRentalVehicleService rentalVehicleService)
        {
            _context = context;
            _rentalVehicleService = rentalVehicleService;
        }

        // GET: RentalVehicles
        public IActionResult Index()
        {
            return View(_rentalVehicleService.GetAllRentalVehicles());
        }

        // GET: RentalVehicles/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalVehicle = _rentalVehicleService.GetRentalVehicle(id);
            if (rentalVehicle == null)
            {
                return NotFound();
            }

            return View(rentalVehicle);
        }

        // GET: RentalVehicles/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id");
            return View();
        }

        // POST: RentalVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("VehicleId,MinimumRentalTime,MaximumRentalTime,DailyRentalRate,isAvailable,Id")] RentalVehicle rentalVehicle)
        {
            if (ModelState.IsValid)
            {
                // rentalVehicle.Id = Guid.NewGuid();
                _rentalVehicleService.CreateRentalVehicle(rentalVehicle);
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", rentalVehicle.VehicleId);
            return View(rentalVehicle);
        }

        // GET: RentalVehicles/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalVehicle = _rentalVehicleService.GetRentalVehicle(id);
            if (rentalVehicle == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", rentalVehicle.VehicleId);
            return View(rentalVehicle);
        }

        // POST: RentalVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("VehicleId,MinimumRentalTime,MaximumRentalTime,DailyRentalRate,isAvailable,Id")] RentalVehicle rentalVehicle)
        {
            if (id != rentalVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _rentalVehicleService.UpdateRentalVehicle(rentalVehicle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalVehicleExists(rentalVehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", rentalVehicle.VehicleId);
            return View(rentalVehicle);
        }

        // GET: RentalVehicles/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalVehicle = _rentalVehicleService.GetRentalVehicle(id);

            if (rentalVehicle == null)
            {
                return NotFound();
            }

            return View(rentalVehicle);
        }

        // POST: RentalVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var rentalVehicle = _rentalVehicleService.GetRentalVehicle(id);
            if (rentalVehicle != null)
            {
                _rentalVehicleService.DeleteRentalVehicle(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RentalVehicleExists(Guid id)
        {
            return _context.RentalVehicles.Any(e => e.Id == id);
        }
    }
}
