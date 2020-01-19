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
    [Authorize(Roles = "Admin")]
    public class DisasterTypesController : Controller
    {
        private readonly BeTheChangeContext _context;

        public DisasterTypesController(BeTheChangeContext context)
        {
            _context = context;
        }

        // GET: DisasterTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DisasterType.ToListAsync());
        }

        // GET: DisasterTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterType = await _context.DisasterType
                .FirstOrDefaultAsync(m => m.DtypeName == id);
            if (disasterType == null)
            {
                return NotFound();
            }

            return View(disasterType);
        }

        // GET: DisasterTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisasterTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DtypeName")] DisasterType disasterType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disasterType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disasterType);
        }

        // GET: DisasterTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterType = await _context.DisasterType.FindAsync(id);
            if (disasterType == null)
            {
                return NotFound();
            }
            return View(disasterType);
        }

        // POST: DisasterTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DtypeName")] DisasterType disasterType)
        {
            if (id != disasterType.DtypeName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disasterType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisasterTypeExists(disasterType.DtypeName))
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
            return View(disasterType);
        }

        // GET: DisasterTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterType = await _context.DisasterType
                .FirstOrDefaultAsync(m => m.DtypeName == id);
            if (disasterType == null)
            {
                return NotFound();
            }

            return View(disasterType);
        }

        // POST: DisasterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var disasterType = await _context.DisasterType.FindAsync(id);
            _context.DisasterType.Remove(disasterType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisasterTypeExists(string id)
        {
            return _context.DisasterType.Any(e => e.DtypeName == id);
        }
    }
}
