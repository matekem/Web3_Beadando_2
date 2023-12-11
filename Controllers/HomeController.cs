using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
using Web3_Beadando.Models;
using Web3_Beadando.Services;

namespace Web3_Beadando.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to the Home Page!";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Timetable()
        {
            return View();
        }
        public IActionResult Assignments()
        {
            return View();
        }
        public IActionResult Stats()
        {
            return View();
        }
        public IActionResult Export()
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