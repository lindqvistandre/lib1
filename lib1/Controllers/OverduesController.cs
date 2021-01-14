using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lib1.Data;
using Lib1.Models;

namespace lib1.Controllers
{
    public class OverduesController : Controller
    {
        private readonly Lib1DbContext _context;

        public OverduesController(Lib1DbContext context)
        {
            _context = context;
        }

        // GET: Overdues
        public async Task<IActionResult> Index()
        {
            var lib1dbcontext = _context.Rentals
              .Include(r => r.Member)
              .Include(r => r.Inventory)
              .Where(r => r.RentDue < DateTime.Now && r.ReturnDate == null);
            return View(await lib1dbcontext.ToListAsync());
            //var Lib1DbContext = _context.Rentals // (b => b.RentalDate.AddDays(30) < DateTime.Now)
            //    .Include(b => b.Inventory)
            //    .ThenInclude(b => b.Book) // .ThenInclude (b => b.Book).
            //    .Include(b => b.Member).Where(b => b.ReturnDate == null);
            //return View(await Lib1DbContext.ToListAsync());
        
    }

        // GET: Overdues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Inventory)
                .Include(r => r.Member)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Overdues/Create
        public IActionResult Create()
        {
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId");
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "FirstName");
            return View();
        }

        // POST: Overdues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalId,InventoryId,MemberId,RentalDate,ReturnDate,RentDue")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", rental.InventoryId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "FirstName", rental.MemberId);
            return View(rental);
        }

        // GET: Overdues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", rental.InventoryId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "FirstName", rental.MemberId);
            return View(rental);
        }

        // POST: Overdues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalId,InventoryId,MemberId,RentalDate,ReturnDate,RentDue")] Rental rental)
        {
            if (id != rental.RentalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.RentalId))
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
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "InventoryId", "InventoryId", rental.InventoryId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "FirstName", rental.MemberId);
            return View(rental);
        }

        // GET: Overdues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Inventory)
                .Include(r => r.Member)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Overdues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.RentalId == id);
        }
    }
}
