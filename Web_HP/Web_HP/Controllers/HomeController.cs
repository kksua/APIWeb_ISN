﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
