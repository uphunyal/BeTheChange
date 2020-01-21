using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeTheChangeFinal.Models;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Index(string searchstring)

            
        {
            var disasters = from m in _context.Disaster
                            select m;
            
            if (!String.IsNullOrEmpty(searchstring))
            {
                disasters = disasters.Include(c => c.DtypeNameNavigation).Where(s => s.DtypeName.Contains(searchstring)).OrderByDescending(c=>c.Urgency);
                return View(await disasters.ToListAsync());
            }

            
            var beTheChangeContext = _context.Disaster.Include(d => d.DtypeNameNavigation).OrderByDescending(c=>c.Urgency);
          
            return View(await beTheChangeContext.ToListAsync());
        }

        // GET: Disasters/Details/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disaster = await _context.Disaster.FindAsync(id);
            _context.Disaster.Remove(disaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Tap for a cause
        //Randomly selected Charity
        public IActionResult TapForCause()
        {
            int disastercount = _context.Disaster.Count();
            Console.WriteLine("The number of Charity Count" + disastercount);
            Random r = new Random();
            int selectedno = r.Next(3, disastercount+2);
            var disaster = _context.Disaster.Include(c => c.DtypeNameNavigation).Where(c => c.DisasterId == selectedno);

             

            Console.WriteLine(disaster.Count());
            return View(disaster);

        }
        private bool DisasterExists(int id)
        {
            return _context.Disaster.Any(e => e.DisasterId == id);
        }
    }
}
