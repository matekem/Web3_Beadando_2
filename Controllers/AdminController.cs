using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web3_Beadando.Areas.Identity.Data;
using Web3_Beadando.Models;
using Web3_Beadando.Services;

namespace Web3_Beadando.Controllers
{
    [Authorize(Roles = "Teacher,Sysadmin")]
    public class AdminController : Controller
    {
        private readonly SchoolContext _dbContext;
        private readonly SchoolService _schoolService;

        public AdminController(SchoolContext dbContext, SchoolService schoolService )
        {
            this._dbContext = dbContext;
            this._schoolService = schoolService;
        }

        #region Return Views

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewSubject()
        {
            ViewData["Title"] = "Subjects";
            return View();
        }

        public IActionResult NewClassroom()
        {
            return View();
        }

        public IActionResult NewClass()
        {
            return View();
        }

        public IActionResult Assignments()
        {
            return View();
        }

        public IActionResult CreateNewUser()
        {
            return View();
        }

        public IActionResult NewCategory()
        {
            return View();
        }


        [Authorize(Roles = "Sysadmin")]
        public IActionResult DeleteUser()
        {
            return View();
        }

        #endregion

        #region Post methods

        [HttpPost]
        public IActionResult NewSubject(Subject subject)
        {
            //create new subject from formdata
            subject.Id = new Guid();
            subject.Name = Request.Form["SubjectName"];
            subject.TeacherId = Request.Form["TeacherId"];

            _schoolService.CreateSubject(subject);

            TempData["SuccessMessage"] = "Subject created";

            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult NewClassroom(Classroom classroom)
        {
            classroom.Name = Request.Form["ClassroomName"];
            classroom.Id = new Guid();
            
            classroom.isLab = Request.Form["isLab"] == "on";
            if (classroom.isLab)
            {
                classroom.SubjectId  = new Guid(Request.Form["SubjectId"]);
            }
            else
            {
                classroom.SubjectId = Guid.Empty;
            }

            _schoolService.CreateClassroom(classroom);


            TempData["SuccessMessage"] = "Classroom created";

            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult NewClass(Class myClass)
        {
            myClass.Id = new Guid();
            myClass.SubjectId = new Guid(Request.Form["SubjectId"]);
            myClass.Day = Request.Form["Day"];
            myClass.StartTime = new TimeOnly(int.Parse(Request.Form["StartTime"].ToString().Split(":")[0]), int.Parse(Request.Form["StartTime"].ToString().Split(":")[1]), 0);
            myClass.Duration = int.Parse(Request.Form["classDuration"]);
            myClass.ClassroomId = new Guid(Request.Form["ClassroomId"]);

            _schoolService.CreateClass(myClass);

            TempData["SuccessMessage"] = "Class created";

            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult Assignments(Assignment assignment)
        {
            assignment.Id = new Guid();
            assignment.SubjectId = new Guid(Request.Form["SubjectId"]);
            assignment.Title = Request.Form["Title"];
            assignment.Description = Request.Form["Description"];
            assignment.Deadline = DateTime.Parse(Request.Form["DeadLine"]);
            assignment.Deadline = assignment.Deadline.AddHours(23).AddMinutes(59).AddSeconds(59);
            assignment.CategoryId = new Guid(Request.Form["Category"]);

            _schoolService.CreateAssignment(assignment);

            TempData["SuccessMessage"] = "Assignment created";

            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult NewCategory(Category category)
        {
            category.Id = new Guid();
            category.Name = Request.Form["CategoryName"];

            _schoolService.CreateCategory(category);

            TempData["SuccessMessage"] = "Category created";
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult DeleteClassroom(Guid id)
        {
            string name = _schoolService.GetClassroomById(id).Name;
            _schoolService.DeleteClassroom(id);
            TempData["SuccessMessage"] = $"Classroom \"{name}\" deleted.";
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult DeleteSubject(Guid id)
        {
            string name = _schoolService.GetSubjectById(id).Name;
            _schoolService.DeleteSubject(id);
            TempData["SuccessMessage"] = $"Subject \"{name}\" deleted.";
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult DeleteAssignment(Guid id)
        {
            string name = _schoolService.GetAssignmentById(id).Title;
            _schoolService.DeleteAssignment(id);
            TempData["SuccessMessage"] = $"Assignment \"{name}\" deleted.";
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult DeleteClass(Guid id)
        {
            _schoolService.DeleteClass(id);
            TempData["SuccessMessage"] = $"Class deleted.";
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult DeleteCategory(Guid id)
        {
            string name = _schoolService.GetCategoryById(id).Name;
            _schoolService.DeleteCategory(id);
            TempData["SuccessMessage"] = $"Category \"{name}\" deleted.";
            return Redirect("~/");
        }

        [Authorize(Roles = "Sysadmin")]
        [HttpPost]
        public IActionResult DeleteUser(string id)
        {
            string name = _schoolService.GetUserById(id).UserName;
            _schoolService.DeleteUser(id);
            TempData["SuccessMessage"] = $"User \"{name}\" deleted.";
            return Redirect("~/");
        }

        #endregion

    }
}
