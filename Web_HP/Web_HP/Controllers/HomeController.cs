using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_HP.Models;

namespace Web_HP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Login()
        {
            // Redirect to the Login action in the Login controller
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Albums()
        {
            return View();
        }

        public IActionResult Chansons()
        {
            return View();
        }

        public IActionResult Chanteurs()
        {
            return View();
        }

        public IActionResult Movies()
        {
            return View();
        }
        public IActionResult Series()
        {
            return View();
        }
        public IActionResult Acteurs()
        {
            return View();
        }
        public IActionResult Directeurs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
