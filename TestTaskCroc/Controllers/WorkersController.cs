#nullable enable
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskCroc.Models;

namespace TestTaskCroc.Controllers
{
    public class WorkersController : Controller
    {
        private readonly PGDbContext _context;
        public WorkersController(PGDbContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            return View(_context.Workers.ToList());
        }
        
        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workers = await _context.Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workers == null)
            {
                return NotFound();
            }

            return View(workers);
        }

        // POST: Cars/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Workers? workers = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(workers ?? throw new InvalidOperationException());
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Workers? workers = await _context.Workers.FindAsync(id);
            if (workers == null)
            {
                return NotFound();
            }
            return View(workers);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Birthday,PassportNumber")] Workers workers)
        {
            if (id != workers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction("Index");
            }
            return View(workers);
        }
        
        public IActionResult CreateNew()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew([Bind("FullName,Birthday,PassportNumber")] Workers workers)
        {
            try
            {
                await _context.Workers.AddAsync(workers);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            return View(workers);
        }
    }
}