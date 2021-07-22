#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskCroc.Models;

namespace TestTaskCroc.Controllers
{
    public class CarsController : Controller
    {
        private readonly PGDbContext _context;
        public CarsController(PGDbContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            return View(_context.Cars.ToList());
        }
        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cars? car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Brand,Model,GovNumber,TypeOfGearShiftBox,EngineVolume,EngineForce,DepreciationCoef,InsuranceCoef,MaintenanceCoef,CarCost,DateOfPurchase")] Cars car)
        {
            if (id != car.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction("Index");
            }
            return View(car);
        }
        
        public IActionResult CreateNew()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew([Bind("Brand,Model,GovNumber,TypeOfGearShiftBox,EngineVolume,EngineForce,DepreciationCoef,InsuranceCoef,MaintenanceCoef,CarCost,DateOfPurchase")] Cars car)
        {
                try
                {
                    await _context.Cars.AddAsync(car);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return View(car);
        }
        
        
        
        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.ID == id);

            float sumRange = _context.Trips.Where(p=>car != null && p.CarId==car.ID)
                .Sum(p => p.Range);
            if (car != null)
            {
                DateTime currentDate = car.DateOfPurchase;
                List<float> returnPriceList = new List<float>();
                float currentPrice = (float)car.CarCost;
                returnPriceList.Add(currentPrice);
                List<DateTime> datesList = new List<DateTime> {currentDate};
                while (currentDate<=DateTime.Now)
                {
                    float gsmMonthCost = _context.Trips.Where(
                            p=>p.CarId==car.ID&&p.EndTime>=currentDate&&p.EndTime<currentDate.AddMonths(1))
                        .Sum(p => p.CostOfSpentFuel);
                    currentPrice = currentPrice - currentPrice*0.001f / (float) (car.DepreciationCoef)
                                                -currentPrice*0.001f / (float)car.InsuranceCoef
                                                -currentPrice*0.001f / (float)car.MaintenanceCoef 
                                                - (float) (car.EngineVolume * car.CarCost*0.000001m) 
                                                - gsmMonthCost;
                    returnPriceList.Add(currentPrice);
                    datesList.Add(currentDate);
                    currentDate = currentDate.AddMonths(1);
                }
                ViewBag.ReturnPrice_List = returnPriceList;  
                ViewBag.Dates_List = datesList;
                ViewBag.LastCost = returnPriceList.Last();
            }

            ViewBag.SumRange = sumRange;
            if (car == null)
            {
                return NotFound();
            }

            return View();
        }
        
        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Cars? car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car ?? throw new InvalidOperationException());
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}