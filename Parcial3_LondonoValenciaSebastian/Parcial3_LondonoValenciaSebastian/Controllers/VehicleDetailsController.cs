using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial3_LondonoValenciaSebastian.DAL;
using Parcial3_LondonoValenciaSebastian.DAL.Entities;

namespace Parcial3_LondonoValenciaSebastian.Controllers
{
    public class VehicleDetailsController : Controller
    {
        private readonly DataBaseContext _context;

        public VehicleDetailsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: VehicleDetails
        public async Task<IActionResult> Index()
        {
            var dataBaseContext = _context.VehicleDetails.Include(v => v.Vehicle);
            return View(await dataBaseContext.ToListAsync());
        }

        // GET: VehicleDetails/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.VehicleDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehicleDetails
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "NumberPlate");
            return View();
        }

        // POST: VehicleDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleId,DeliveryDate,PriceService")] VehicleDetails vehicleDetails)
        {
            if (ModelState.IsValid)
            {
                vehicleDetails.Id = Guid.NewGuid();
                _context.Add(vehicleDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "NumberPlate", vehicleDetails.VehicleId);
            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.VehicleDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehicleDetails.FindAsync(id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "NumberPlate", vehicleDetails.VehicleId);
            return View(vehicleDetails);
        }

        // POST: VehicleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,VehicleId,DeliveryDate,PriceService")] VehicleDetails vehicleDetails)
        {
            if (id != vehicleDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleDetailsExists(vehicleDetails.Id))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "NumberPlate", vehicleDetails.VehicleId);
            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.VehicleDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehicleDetails
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return View(vehicleDetails);
        }

        // POST: VehicleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.VehicleDetails == null)
            {
                return Problem("Entity set 'DataBaseContext.VehicleDetails'  is null.");
            }
            var vehicleDetails = await _context.VehicleDetails.FindAsync(id);
            if (vehicleDetails != null)
            {
                _context.VehicleDetails.Remove(vehicleDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleDetailsExists(Guid id)
        {
          return (_context.VehicleDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
