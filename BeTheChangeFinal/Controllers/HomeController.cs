using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeTheChangeFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace BeTheChangeFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       /* private readonly BeTheChangeContext _context;

        public HomeController(BeTheChangeContext context)
        {
            _context = context;
        }*/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /*public async Task<IActionResult> TapForChange()
        {
            Random r = new Random();
            int selectedno = r.Next(0, 1);
            if (selectedno == 0)
            {
                int charitycount = _context.Charity.Count();

                var context = _context.Charity.Where(c => c.CharityId == r.Next(0, charitycount));
                return View(await context.ToListAsync());
            }
           else {

                int disaster_count = _context.Disaster.Count();

                var context = _context.Charity.Where(c => c.CharityId == r.Next(0, disaster_count));
                return View(await context.ToListAsync());
            }
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
