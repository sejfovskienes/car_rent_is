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
    public class RentedVehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRentedVehicleService _rentedVehicleService;

        public RentedVehiclesController(ApplicationDbContext context, IRentedVehicleService rentedVehicleService)
        {
            _context = context;
            _rentedVehicleService = rentedVehicleService;
        }

        // GET: RentedVehicles
        public IActionResult Index()
        {
            return View(_rentedVehicleService.GetAllRentedVehicles());
        }

        // GET: RentedVehicles/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedVehicle = _rentedVehicleService.GetRentedVehicle(id);

            if (rentedVehicle == null)
            {
                return NotFound();
            }

            return View(rentedVehicle);
        }

        // GET: RentedVehicles/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["RentalVehicleId"] = new SelectList(_context.RentalVehicles, "Id", "Id");
            return View();
        }

        // POST: RentedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RentalVehicleId,UserId,StartDate,EndDate,Charge,Id")] RentedVehicle rentedVehicle)
        {
            if (ModelState.IsValid)
            {
                //rentedVehicle.Id = Guid.NewGuid();
                _rentedVehicleService.CreateRentedVehicle(rentedVehicle);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rentedVehicle.UserId);
            ViewData["RentalVehicleId"] = new SelectList(_context.RentalVehicles, "Id", "Id", rentedVehicle.RentalVehicleId);
            return View(rentedVehicle);
        }

        // GET: RentedVehicles/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedVehicle = _rentedVehicleService.GetRentedVehicle(id);
            if (rentedVehicle == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rentedVehicle.UserId);
            ViewData["RentalVehicleId"] = new SelectList(_context.RentalVehicles, "Id", "Id", rentedVehicle.RentalVehicleId);
            return View(rentedVehicle);
        }

        // POST: RentedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("RentalVehicleId,UserId,StartDate,EndDate,Charge,Id")] RentedVehicle rentedVehicle)
        {
            if (id != rentedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _rentedVehicleService.UpdateRentedVehicle(rentedVehicle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentedVehicleExists(rentedVehicle.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rentedVehicle.UserId);
            ViewData["RentalVehicleId"] = new SelectList(_context.RentalVehicles, "Id", "Id", rentedVehicle.RentalVehicleId);
            return View(rentedVehicle);
        }

        // GET: RentedVehicles/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedVehicle = _rentedVehicleService.GetRentedVehicle(id);

            if (rentedVehicle == null)
            {
                return NotFound();
            }

            return View(rentedVehicle);
        }

        // POST: RentedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var rentedVehicle = _rentedVehicleService.GetRentedVehicle(id);
            if (rentedVehicle != null)
            {
                _rentedVehicleService.DeleteRentalVehicle(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RentedVehicleExists(Guid id)
        {
            return _context.RentedVehicles.Any(e => e.Id == id);
        }
    }
}
