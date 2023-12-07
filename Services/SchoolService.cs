using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Web3_Beadando.Areas.Identity.Data;
using Web3_Beadando.Migrations;
using Web3_Beadando.Models;

namespace Web3_Beadando.Services
{
    public class SchoolService
    {
        private SchoolContext _dbContext;
        public List<ApplicationUser> users;
        public List<ApplicationUser> teachers;
        public List<Subject> subjects;
        public List<Classroom> classrooms;
        public List<Class> classes;
        public List<Assignment> assignments;

        public SchoolService()

        {
            _dbContext = ConnectToDB();
            users = GetAllStudents();
            teachers = GetAllTeachers();
            subjects = GetAllSubjects();
            classrooms = GetAllClassrooms();
            classes = GetAllClasses();
            assignments = GetAllAssignments();
        }

        private SchoolContext ConnectToDB()
        {
            var connectionString = "Data Source = Data.db";
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlite(connectionString);
            _dbContext = new SchoolContext(optionsBuilder.Options);
            return _dbContext;
        }

        public List<ApplicationUser> GetAllTeachers()
        {
            List<ApplicationUser> teachers = new List<ApplicationUser>();

            foreach (var user in _dbContext.Users)
            {
                if (user.Role == "Teacher")
                {
                    teachers.Add(user);
                }
            }

            return teachers;
        }

        public List<ApplicationUser> GetAllStudents()
        {
            List<ApplicationUser> students = new List<ApplicationUser>();

            if(_dbContext == null)
            {
                _dbContext = null;
            }

            foreach (var user in _dbContext.Users)
            {
                if (user.Role == "Student")
                {
                    students.Add(user);
                }
            }

            return students;
        }

        public List<Subject> GetAllSubjects()
        {
               List<Subject> subjects = new List<Subject>();

            foreach (var subject in _dbContext.Subjects)
            {
                subjects.Add(subject);
            }

            return subjects;
        }

        public List<Classroom> GetAllClassrooms()
        {
            List<Classroom> classrooms = new List<Classroom>();

            foreach (var classroom in _dbContext.Classrooms)
            {
                classrooms.Add(classroom);
            }

            return classrooms;
        }

        public List<Class> GetAllClasses()
        {
            List<Class> classes = new List<Class>();

            foreach (var classs in _dbContext.Classes)
            {
                classes.Add(classs);
            }

            return classes;
        }

        public List<Assignment> GetAllAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();

            foreach (var assignment in _dbContext.Assignments)
            {
                assignments.Add(assignment);
            }

            return assignments;
        }

        public List<Subject> GetSubjectsById(Guid id)
        {
            var subjects = new List<Subject>();

            foreach (var subject in _dbContext.Subjects)
            {
                if (subject.Id == id)
                {
                    subjects.Add(subject);
                }
            }
            return subjects;
        }

        public Subject GetSubjectById(Guid id)
        {
            var subject = new Subject();

            foreach(var subj in _dbContext.Subjects)
            {
                if(subj.Id == id)
                {
                    subject = subj;
                }
            }
            return subject;
        }

        public ApplicationUser GetUserById(string id) 
        {
            var user = new ApplicationUser();

            foreach (var usr in _dbContext.Users)
            {
                if (usr.Id == id)
                {
                    user = usr;
                }
            }
            return user;
        }

        public Classroom GetClassroomById(Guid id)
        {
            var classroom = new Classroom();

            foreach (var classr in _dbContext.Classrooms)
            {
                if (classr.Id == id)
                {
                    classroom = classr;
                }
            }
            return classroom;
        }
    }
}
