#nullable enable
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestTaskCroc.Models;

namespace TestTaskCroc.Controllers
{
    public class TripsController : Controller
    {
        private readonly PGDbContext _context;
        public TripsController(PGDbContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            var trips = _context.Trips.Include(p => p.Car).Include(p => p.Worker);
            return View(trips.ToList());
        }
        
        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trips = await _context.Trips
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trips == null)
            {
                return NotFound();
            }

            return View(trips);
        }

        // POST: Cars/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Trips? trips = await _context.Trips.FindAsync(id);
            _context.Trips.Remove(trips ?? throw new InvalidOperationException());
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trips? trips = await _context.Trips.FindAsync(id);
            ViewBag.Cars = new SelectList(_context.Cars, "ID", "GovNumber",trips.CarId);
            ViewBag.Workers = new SelectList(_context.Workers, "Id", "PassportNumber",trips.WorkerId);
            if (trips == null)
            {
                return NotFound();
            }
            return View(trips);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Trips trips)
        {
            if (id != trips.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(trips).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction("Index");
            }
            return View(trips);
        }
        
        public IActionResult CreateNew()
        {
            ViewBag.Cars = new SelectList(_context.Cars, "ID", "GovNumber");
            ViewBag.Workers = new SelectList(_context.Workers, "Id", "PassportNumber");

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew(Trips trips)
        {
            try
            {
                await _context.Trips.AddAsync(trips);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            return View(trips);
        }
    }
}