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
    
    public class CharitiesController : Controller
    {
        private readonly BeTheChangeContext _context;

        public CharitiesController(BeTheChangeContext context)
        {
            _context = context;
        }

        // GET: Charities
        public async Task<IActionResult> Index( string searchstring)
           
        {
            var charities = from m in _context.Charity
                            select m;
            var beTheChangeContext = _context.Charity.Include(c => c.CtypeNameNavigation);
            if (!String.IsNullOrEmpty(searchstring))
            {
                charities = charities.Include(c=>c.CtypeNameNavigation).Where(s => s.CharityOrganization.Contains(searchstring));
                return View(await charities.ToListAsync());
            }
            

            return View(await beTheChangeContext.ToListAsync());
        }

        // GET: Charities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charity = await _context.Charity
                .Include(c => c.CtypeNameNavigation)
                .FirstOrDefaultAsync(m => m.CharityId == id);
            if (charity == null)
            {
                return NotFound();
            }

            return View(charity);
        }

        // GET: Charities/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CtypeName"] = new SelectList(_context.CharityType, "CtypeName", "CtypeName");
            return View();
        }

        // POST: Charities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharityId,CharityDetails,CharityName,CharityOrganization,CharityLocation,CharityLink,CtypeName")] Charity charity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(charity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CtypeName"] = new SelectList(_context.CharityType, "CtypeName", "CtypeName", charity.CtypeName);
            return View(charity);
        }

        // GET: Charities/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charity = await _context.Charity.FindAsync(id);
            if (charity == null)
            {
                return NotFound();
            }
            ViewData["CtypeName"] = new SelectList(_context.CharityType, "CtypeName", "CtypeName", charity.CtypeName);
            return View(charity);
        }

        // POST: Charities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharityId,CharityDetails,CharityName,CharityOrganization,CharityLocation,CharityLink,CtypeName")] Charity charity)
        {
            if (id != charity.CharityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharityExists(charity.CharityId))
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
            ViewData["CtypeName"] = new SelectList(_context.CharityType, "CtypeName", "CtypeName", charity.CtypeName);
            return View(charity);
        }

        // GET: Charities/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charity = await _context.Charity
                .Include(c => c.CtypeNameNavigation)
                .FirstOrDefaultAsync(m => m.CharityId == id);
            if (charity == null)
            {
                return NotFound();
            }

            return View(charity);
        }

        // POST: Charities/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var charity = await _context.Charity.FindAsync(id);
            _context.Charity.Remove(charity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Randomly selected Charity
        public  IActionResult TapForCause()
        {
            int charitycount = _context.Charity.Count();
            Console.WriteLine("The number of Charity Count" + charitycount);
            Random r = new Random();
            int selectedno = r.Next(1, charitycount);
            var charity = _context.Charity.Include(c => c.CtypeNameNavigation).Where(c => c.CharityId == charitycount);



            Console.WriteLine(charity.Count());
            return View( charity);
            
        }
        private bool CharityExists(int id)
        {
            return _context.Charity.Any(e => e.CharityId == id);
        }
    }
}
