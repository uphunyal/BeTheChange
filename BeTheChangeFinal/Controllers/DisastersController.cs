using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeTheChangeFinal.Models;

namespace BeTheChangeFinal.Controllers
{
    public class DisastersController : Controller
    {
        private readonly BeTheChangeContext _context;

        public DisastersController(BeTheChangeContext context)
        {
            _context = context;
        }

        // GET: Disasters
        public async Task<IActionResult> Index()
        {
            var beTheChangeContext = _context.Disaster.Include(d => d.DtypeNameNavigation);
            return View(await beTheChangeContext.ToListAsync());
        }

        // GET: Disasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disaster
                .Include(d => d.DtypeNameNavigation)
                .FirstOrDefaultAsync(m => m.DisasterId == id);
            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }

        // GET: Disasters/Create
        public IActionResult Create()
        {
            ViewData["DtypeName"] = new SelectList(_context.DisasterType, "DtypeName", "DtypeName");
            return View();
        }

        // POST: Disasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisasterId,DisasterName,DisasterDetails,DisasterLocation,DisasterLink,Urgency,DtypeName")] Disaster disaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DtypeName"] = new SelectList(_context.DisasterType, "DtypeName", "DtypeName", disaster.DtypeName);
            return View(disaster);
        }

        // GET: Disasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disaster.FindAsync(id);
            if (disaster == null)
            {
                return NotFound();
            }
            ViewData["DtypeName"] = new SelectList(_context.DisasterType, "DtypeName", "DtypeName", disaster.DtypeName);
            return View(disaster);
        }

        // POST: Disasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisasterId,DisasterName,DisasterDetails,DisasterLocation,DisasterLink,Urgency,DtypeName")] Disaster disaster)
        {
            if (id != disaster.DisasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisasterExists(disaster.DisasterId))
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
            ViewData["DtypeName"] = new SelectList(_context.DisasterType, "DtypeName", "DtypeName", disaster.DtypeName);
            return View(disaster);
        }

        // GET: Disasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disaster
                .Include(d => d.DtypeNameNavigation)
                .FirstOrDefaultAsync(m => m.DisasterId == id);
            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }

        // POST: Disasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disaster = await _context.Disaster.FindAsync(id);
            _context.Disaster.Remove(disaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisasterExists(int id)
        {
            return _context.Disaster.Any(e => e.DisasterId == id);
        }
    }
}
