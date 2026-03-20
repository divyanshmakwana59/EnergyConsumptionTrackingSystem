using Microsoft.AspNetCore.Mvc;

namespace EnergyTrackerProject.Controllers
{
    public class TipsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}