using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web3_Beadando.Models;

namespace Web3_Beadando.Areas.Identity.Data;

public class SchoolContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
