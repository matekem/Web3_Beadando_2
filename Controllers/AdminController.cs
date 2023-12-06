using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web3_Beadando.Models;
using Web3_Beadando.Views.Admin;

namespace Web3_Beadando.Controllers
{
    public class AdminController : Controller
    {
        public HttpContext Context { get; set; }

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
        [HttpPost]
        public IActionResult NewSubject(Subject subject)
        {

            Console.WriteLine(subject.Name);
            return Redirect("~/Admin");
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

        [Authorize(Roles = "Teacher")]
        public IActionResult CreateNewUser()
        {
            return View();
        }

    }
}
