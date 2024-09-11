using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentApp.Domain.Models;
using CarRentApp.Repository;

namespace CarRentApp.Web.Controllers
{
    public class RentedVehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentedVehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentedVehicles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RentedVehicles.Include(r => r.User).Include(r => r.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RentedVehicles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedVehicle = await _context.RentedVehicles
                .Include(r => r.User)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("RentalVehicleId,UserId,StartDate,EndDate,Charge,Id")] RentedVehicle rentedVehicle)
        {
            if (ModelState.IsValid)
            {
                rentedVehicle.Id = Guid.NewGuid();
                _context.Add(rentedVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", rentedVehicle.UserId);
            ViewData["RentalVehicleId"] = new SelectList(_context.RentalVehicles, "Id", "Id", rentedVehicle.RentalVehicleId);
            return View(rentedVehicle);
        }

        // GET: RentedVehicles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedVehicle = await _context.RentedVehicles.FindAsync(id);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("RentalVehicleId,UserId,StartDate,EndDate,Charge,Id")] RentedVehicle rentedVehicle)
        {
            if (id != rentedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentedVehicle);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedVehicle = await _context.RentedVehicles
                .Include(r => r.User)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentedVehicle == null)
            {
                return NotFound();
            }

            return View(rentedVehicle);
        }

        // POST: RentedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var rentedVehicle = await _context.RentedVehicles.FindAsync(id);
            if (rentedVehicle != null)
            {
                _context.RentedVehicles.Remove(rentedVehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentedVehicleExists(Guid id)
        {
            return _context.RentedVehicles.Any(e => e.Id == id);
        }
    }
}
