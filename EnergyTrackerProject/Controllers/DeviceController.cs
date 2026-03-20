using Microsoft.AspNetCore.Mvc;
using EnergyTrackerProject.Data;
using EnergyTrackerProject.Models;
using System.Linq;

namespace EnergyTrackerProject.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var devices = _context.Devices.ToList();
            return View(devices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Device device)
        {
            _context.Devices.Add(device);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // Edit Device
        public IActionResult Edit(int id)
        {
            var device = _context.Devices.Find(id);
            return View(device);
        }

        [HttpPost]
        public IActionResult Edit(Device device)
        {
            _context.Devices.Update(device);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // Delete Device
        public IActionResult Delete(int id)
        {
            var device = _context.Devices.Find(id);

            if (device != null)
            {
                _context.Devices.Remove(device);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}