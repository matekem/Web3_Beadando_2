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
        public NewSubjectModel()
        {
            
        }
        //public Subject SubjectToAdd { get; set; }
        //private readonly SchoolContext _dbContext;
        //public SelectList Teachers { get; set; }
        //public int SelectedTeacherId { get; set; }


        //public void OnGet() 
        //{

        //    var teachers = _dbContext.Teachers.ToList();

        //    Teachers = new SelectList(teachers, "Id", "FullName");
        //    Console.WriteLine("ONGET");

        //}


        //public void OnPost()
        //{

        //    Console.WriteLine("ONPOST");


        //}
    }

}
