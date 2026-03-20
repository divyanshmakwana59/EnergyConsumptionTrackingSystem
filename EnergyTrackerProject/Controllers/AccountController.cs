using EnergyTrackerProject.Data;
using EnergyTrackerProject.Models;
using EnergyTrackerProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EnergyTrackerProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user != null)
                return RedirectToAction("Index", "Dashboard");

            ViewBag.Error = "Invalid Login";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            User user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}