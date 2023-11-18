using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web3_Beadando.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Teacher")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult NewSubject()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult NewClassroom()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult EditSubject()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Assignments()
        {
            return View();
        }

    }
}
