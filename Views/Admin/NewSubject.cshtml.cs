using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web3_Beadando.Areas.Identity.Data;
using Web3_Beadando.Models;

namespace Web3_Beadando.Views.Admin
{
    public class NewSubject : PageModel
    {
        public Subject SubjectToAdd { get; set; }
        private readonly SchoolContext _dbContext;

        public IActionResult OnPostAsync()
        {
            
            Teacher.AddNewSubject(SubjectToAdd.Name, SubjectToAdd.Teacher);

            // Assuming _dbContext is your DbContext
            var newSubject = new Subject
            {
                Name = SubjectToAdd.Name,
                Teacher = SubjectToAdd.Teacher
                // Add any other properties for the Subject model
            };

            _dbContext.Subjects.Add(newSubject);
            _dbContext.SaveChanges();

           return RedirectToPage("/Admin/");
        }
    }
}
