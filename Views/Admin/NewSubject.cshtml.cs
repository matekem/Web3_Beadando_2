using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web3_Beadando.Areas.Identity.Data;
using Web3_Beadando.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web3_Beadando.Views.Admin
{
    public class NewSubjectModel : PageModel
    {
        public Subject SubjectToAdd { get; set; }
        private readonly SchoolContext _dbContext;


        // Property to hold the list of teachers
        public SelectList Teachers { get; set; }
        // Property to hold the selected teacher ID
        [BindProperty]
        public int SelectedTeacherId { get; set; }

        public NewSubjectModel(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet() 
        {

            // Fetch teachers from the database
            var teachers = _dbContext.Teachers.ToList();

            // Create a SelectList
            Teachers = new SelectList(teachers, "Id", "FullName");

        }


        public IActionResult OnPost(Subject subject, Teacher teacher)
        {
            //var selectedTeacher = _dbContext.Teachers.FirstOrDefault(t => t.Id == SelectedTeacherId);

            //Console.WriteLine(selectedTeacher);
            //// Rest of your code...
            return RedirectToPage("/Admin/");
        }
    }

}
