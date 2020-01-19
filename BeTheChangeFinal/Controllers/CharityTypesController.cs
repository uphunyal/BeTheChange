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
    public class CharityTypesController : Controller
    {
        private readonly BeTheChangeContext _context;

        public CharityTypesController(BeTheChangeContext context)
        {
            _context = context;
        }

        // GET: CharityTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CharityType.ToListAsync());
        }

        // GET: CharityTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charityType = await _context.CharityType
                .FirstOrDefaultAsync(m => m.CtypeName == id);
            if (charityType == null)
            {
                return NotFound();
            }

            return View(charityType);
        }

        // GET: CharityTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CharityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CtypeName")] CharityType charityType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(charityType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(charityType);
        }

        // GET: CharityTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charityType = await _context.CharityType.FindAsync(id);
            if (charityType == null)
            {
                return NotFound();
            }
            return View(charityType);
        }

        // POST: CharityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CtypeName")] CharityType charityType)
        {
            if (id != charityType.CtypeName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charityType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharityTypeExists(charityType.CtypeName))
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
            return View(charityType);
        }

        // GET: CharityTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charityType = await _context.CharityType
                .FirstOrDefaultAsync(m => m.CtypeName == id);
            if (charityType == null)
            {
                return NotFound();
            }

            return View(charityType);
        }

        // POST: CharityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var charityType = await _context.CharityType.FindAsync(id);
            _context.CharityType.Remove(charityType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharityTypeExists(string id)
        {
            return _context.CharityType.Any(e => e.CtypeName == id);
        }
    }
}
