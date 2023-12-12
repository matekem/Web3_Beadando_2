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
        public List<ApplicationUser> applicationUsers;
        public List<Subject> subjects;
        public List<Classroom> classrooms;
        public List<Class> classes;
        public List<Assignment> assignments;
        public List<Category> categories; 

        public SchoolService()
        {
            _dbContext = ConnectToDB();
            users = GetAllStudents();
            teachers = GetAllTeachers();
            applicationUsers = GetAllApplicationUsers();
            subjects = GetAllSubjects();
            classrooms = GetAllClassrooms();
            classes = GetAllClasses();
            assignments = GetAllAssignments();
            categories = GetAllCategories();
        }


        private SchoolContext ConnectToDB()
        {
            var connectionString = "Data Source = Data.db";
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlite(connectionString);
            _dbContext = new SchoolContext(optionsBuilder.Options);
            return _dbContext;
        }

        #region GetterMethods


        private List<ApplicationUser>? GetAllApplicationUsers()
        {
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();

            foreach (var user in _dbContext.Users)
            {
                applicationUsers.Add(user);
            }
            return applicationUsers;
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

        public List<Category> GetAllCategories()
        {
            var categories = new List<Category>();

            foreach (var category in _dbContext.Categories)
            {
                categories.Add(category);
            }
            return categories;
        }

        public Category GetCategoryById(Guid id)
        {
            var category = new Category();

            foreach (var cat in _dbContext.Categories)
            {
                if (cat.Id == id)
                {
                    category = cat;
                }
            }
            return category;
        }

        public Assignment GetAssignmentById(Guid id)
        {
            Assignment assignment = new Assignment();

            foreach(Assignment a in _dbContext.Assignments)
            {
                if(a.Id == id)
                {
                    assignment = a;
                }
            }
            return assignment;
        }

        public Class GetClassById(Guid id)
        {
            Class lesson = new();

            foreach (Class l in _dbContext.Classes)
            {
                if (l.Id == id)
                {
                    lesson = l;
                }
            }
            return lesson;
        }

        #endregion

        #region DeleteMethods

        internal void DeleteSubject(Guid id)
        {
            if(id != null)
            {
                var subject = GetSubjectById(id);
                _dbContext.Subjects.Remove(subject);
                _dbContext.SaveChanges();
            }
        }

        internal void DeleteAssignment(Guid id)
        {
           if(id != null)
            {
                var assignment = GetAssignmentById(id);
                _dbContext.Assignments.Remove(assignment);
                _dbContext.SaveChanges();
            }
        }

        internal void DeleteClass(Guid id)
        {
            if(id != null)
            {
                var lesson = GetClassById(id);
                _dbContext.Classes.Remove(lesson);
                _dbContext.SaveChanges();
            }
        }

        internal void DeleteCategory(Guid id)
        {
           if(id != null)
            {
                var category = GetCategoryById(id);
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        internal void DeleteClassroom(Guid id)
        {
            if(id != null)
            {
                var classroom = GetClassroomById(id);
                _dbContext.Classrooms.Remove(classroom);
                _dbContext.SaveChanges();
            }
        }

        internal void DeleteUser(string id)
        {
            if(id != null)
            {
                var user = GetUserById(id);
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }




        #endregion

        #region CreateMethods

        internal void CreateSubject(Subject subject)
        {
            if (subject != null)
            {
                _dbContext.Subjects.Add(subject);
                _dbContext.SaveChanges();
            }

        }

        internal void CreateClassroom(Classroom classroom)
        {
            if(classroom != null)
            {
                _dbContext.Classrooms.Add(classroom);
                _dbContext.SaveChanges();
            }
        }

        internal void CreateClass(Class myClass)
        {
           if(myClass != null)
            {
                _dbContext.Classes.Add(myClass);
                _dbContext.SaveChanges();
            }
        }

        internal void CreateAssignment(Assignment assignment)
        {
            if(assignment != null)
            {
                _dbContext.Assignments.Add(assignment);
                _dbContext.SaveChanges();
            }

        }

        internal void CreateCategory(Category category)
        {
            if (category != null)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
            }
        }

        #endregion
    }
}
