using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Web3_Beadando.Areas.Identity.Data;
using Web3_Beadando.Models;



namespace Web3_Beadando
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<SchoolContext>(options =>
                options.UseSqlite(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

            }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SchoolContext>();


            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Teacher", "Student" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
            
            using (var scope = app.Services.CreateScope())
            {
                var usermanager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string email = "admin@admin.hu";
                string password = "asdQWE123!";

                if (await usermanager.FindByEmailAsync(email) == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        FullName = "Admin User",
                        Role = "Teacher"
                    };

                    var result = await usermanager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        await usermanager.AddToRoleAsync(user, "Teacher");
                    }
                }
            }
            
            //SeedTeacherRoles(app);


            app.Run();
        }

        /*private static void SeedTeacherRoles(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<SchoolContext>();

                // Ensure "Teacher" role exists
                if (!roleManager.RoleExistsAsync("Teacher").Result)
                {
                    var role = new IdentityRole("Teacher");
                    roleManager.CreateAsync(role).Wait();
                }

                // Find users with "Teacher" role
                var teacherUsers = userManager.Users.Where(u => u.Role == "Teacher").ToList();

                foreach (var user in teacherUsers)
                {
                    // Check if the user is not already in the Teachers table
                    if (!dbContext.UserRoles.Any(t => t.UserId == user.Id))
                    {
                        var teacher = new Teacher
                        {
                            Id = user.Id,
                            FullName = user.FullName,
                            Email = user.Email
                                                 
                        };

                        dbContext.Teachers.Add(teacher);
                        dbContext.SaveChanges();
                    }
                }
            }
        }*/




    }
}