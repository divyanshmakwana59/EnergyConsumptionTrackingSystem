using Microsoft.AspNetCore.Mvc;
using EnergyTrackerProject.Data;
using System.Linq;

namespace EnergyTrackerProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalDevices = _context.Devices.Count();
            ViewBag.TotalEnergy = _context.EnergyUsages.Sum(x => x.EnergyConsumed);
            ViewBag.TotalCost = _context.EnergyUsages.Sum(x => x.Cost);

            // Device Energy Data
            var deviceEnergy = _context.EnergyUsages
                .GroupBy(e => e.DeviceId)
                .Select(g => new
                {
                    DeviceId = g.Key,
                    TotalEnergy = g.Sum(x => x.EnergyConsumed)
                }).ToList();

            var deviceLabels = deviceEnergy
                .Select(x => _context.Devices.FirstOrDefault(d => d.DeviceId == x.DeviceId)?.DeviceName)
                .ToList();

            var deviceData = deviceEnergy
                .Select(x => x.TotalEnergy)
                .ToList();

            // Daily Energy Data
            var dailyEnergy = _context.EnergyUsages
                .GroupBy(e => e.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Energy = g.Sum(x => x.EnergyConsumed)
                }).OrderBy(x => x.Date).ToList();

            var dateLabels = dailyEnergy.Select(x => x.Date.ToShortDateString()).ToList();
            var dateEnergy = dailyEnergy.Select(x => x.Energy).ToList();

            ViewBag.DeviceLabels = deviceLabels;
            ViewBag.DeviceEnergy = deviceData;
            ViewBag.DateLabels = dateLabels;
            ViewBag.DateEnergy = dateEnergy;

            return View();
        }
    }
}