using Microsoft.AspNetCore.Mvc;
using EnergyTrackerProject.Data;
using EnergyTrackerProject.Models;
using System;

namespace EnergyTrackerProject.Controllers
{
    public class EnergyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnergyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Track()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Track(EnergyUsage usage, int powerRating)
        {
            decimal energy = (powerRating * usage.HoursUsed) / 1000;
            decimal rate = 7;

            usage.EnergyConsumed = energy;
            usage.Cost = energy * rate;

            _context.EnergyUsages.Add(usage);
            _context.SaveChanges();

            return RedirectToAction("Report");
        }

        public IActionResult Report()
        {
            var data = _context.EnergyUsages.ToList();
            return View(data);
        }
    }
}