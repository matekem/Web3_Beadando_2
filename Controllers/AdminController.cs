using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web3_Beadando.Areas.Identity.Data;
using Web3_Beadando.Migrations;
using Web3_Beadando.Models;
using Web3_Beadando.Services;
using Web3_Beadando.Views.Admin;

namespace Web3_Beadando.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class AdminController : Controller
    {
        private readonly SchoolContext _dbContext;
        private readonly SchoolService _schoolService;

        public AdminController(SchoolContext dbContext, SchoolService schoolService )
        {
            this._dbContext = dbContext;
            this._schoolService = schoolService;
        }

       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewSubject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewSubject(Subject subject)
        {
            //create new subject from formdata
            subject.Id = new System.Guid();
            subject.Name = Request.Form["SubjectName"];
            subject.TeacherId = Request.Form["TeacherId"];
            _dbContext.Subjects.Add(subject);
            _dbContext.SaveChanges();

            return Redirect("~/");
        }


        public IActionResult NewClassroom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewClassroom(Classroom classroom)
        {
            classroom.Name = Request.Form["ClassroomName"];
            classroom.Id = new System.Guid();
            
            classroom.isLab = Request.Form["isLab"] == "on";
            if (classroom.isLab)
            {
                classroom.SubjectId  = new System.Guid(Request.Form["SubjectId"]);
            }
            else
            {
                classroom.SubjectId = Guid.Empty;
            }
            _dbContext.Classrooms.Add(classroom);
            _dbContext.SaveChanges();

            return Redirect("~/");
        }

        public IActionResult NewClass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewClass(Class myClass)
        {
            myClass.Id = new System.Guid();
            myClass.SubjectId = new System.Guid(Request.Form["SubjectId"]);
            myClass.Day = Request.Form["Day"];
            myClass.StartTime = new System.TimeOnly(int.Parse(Request.Form["StartTime"].ToString().Split(":")[0]), int.Parse(Request.Form["StartTime"].ToString().Split(":")[1]), 0);
            myClass.Duration = int.Parse(Request.Form["classDuration"]);
            myClass.ClassroomId = new System.Guid(Request.Form["ClassroomId"]);          
            _dbContext.Classes.Add(myClass);
            _dbContext.SaveChanges();

            return Redirect("~/");
        }

        public IActionResult Assignments()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Assignments(Assignment assignment)
        {
            assignment.Id = new System.Guid();
            assignment.SubjectId = new System.Guid(Request.Form["SubjectId"]);
            assignment.Title = Request.Form["Title"];
            assignment.Description = Request.Form["Description"];
            assignment.Deadline = DateTime.Parse(Request.Form["DeadLine"]);
            assignment.Deadline = assignment.Deadline.AddHours(23).AddMinutes(59).AddSeconds(59);
            assignment.CategoryId = new Guid(Request.Form["Category"]);

            _dbContext.Assignments.Add(assignment);
            _dbContext.SaveChanges();

            TempData["SuccessMessage"] = "Submission was successful!";

            return Redirect("~/");
        }
        public IActionResult CreateNewUser()
        {
            return View();
        }

        public IActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCategory(Category category)
        {
            category.Id = new System.Guid();
            category.Name = Request.Form["CategoryName"];
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return Redirect("~/");
        }

        [HttpPost]        
        public IActionResult DeleteClassroom(Guid id)
        {
            // Perform the deletion logic
            _schoolService.DeleteSubject(id);

            // Redirect to the page where classrooms are displayed
            return RedirectToAction("Index"); // You might need to adjust this based on your route configuration
        }

        [HttpPost]
        public IActionResult DeleteSubject(Guid id)
        {
            // Perform the deletion logic
            _schoolService.DeleteSubject(id);

            // Redirect to the page where classrooms are displayed
            return RedirectToAction("Index"); // You might need to adjust this based on your route configuration
        }

        [HttpPost]
        public IActionResult DeleteAssignment(Guid id)
        {
            // Perform the deletion logic
            _schoolService.DeleteAssignment(id);

            // Redirect to the page where classrooms are displayed
            return RedirectToAction("Index"); // You might need to adjust this based on your route configuration
        }

        [HttpPost]
        public IActionResult DeleteClass(Guid id)
        {
            // Perform the deletion logic
            _schoolService.DeleteClass(id);

            // Redirect to the page where classrooms are displayed
            return RedirectToAction("Index"); // You might need to adjust this based on your route configuration
        }

        [HttpPost]
        public IActionResult DeleteCategory(Guid id)
        {
            // Perform the deletion logic
            _schoolService.DeleteCategory(id);

            // Redirect to the page where classrooms are displayed
            return RedirectToAction("Index"); // You might need to adjust this based on your route configuration
        }
    }
}
