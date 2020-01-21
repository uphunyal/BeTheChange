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
    public class CustomCausesController : Controller
    {
        private readonly BeTheChangeContext _context;

        public CustomCausesController(BeTheChangeContext context)
        {
            _context = context;
        }

        // GET: CustomCauses
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomCauses.ToListAsync());
        }

        
        // GET: CustomCauses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customCauses = await _context.CustomCauses
                .FirstOrDefaultAsync(m => m.CustomId == id);
            if (customCauses == null)
            {
                return NotFound();
            }

            return View(customCauses);
        }

        // GET: CustomCauses/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomCauses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("CustomId,CustomName,CustomDetails,CustomLocation,CauseType,DonateLink,Username")] CustomCauses customCauses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customCauses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customCauses);
        }

        // GET: CustomCauses/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customCauses = await _context.CustomCauses.FindAsync(id);
            if (customCauses == null)
            {
                return NotFound();
            }
            return View(customCauses);
        }

        // POST: CustomCauses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("CustomId,CustomName,CustomDetails,CustomLocation,CauseType,DonateLink,Username")] CustomCauses customCauses)
        {
            if (id != customCauses.CustomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customCauses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomCausesExists(customCauses.CustomId))
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
            return View(customCauses);
        }

        // GET: CustomCauses/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customCauses = await _context.CustomCauses
                .FirstOrDefaultAsync(m => m.CustomId == id);
            if (customCauses == null)
            {
                return NotFound();
            }

            return View(customCauses);
        }

        // POST: CustomCauses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customCauses = await _context.CustomCauses.FindAsync(id);
            _context.CustomCauses.Remove(customCauses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomCausesExists(int id)
        {
            return _context.CustomCauses.Any(e => e.CustomId == id);
        }
    }
}
