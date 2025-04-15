using Eyouth1.Hubs;
using Eyouth1.Models;
using Eyouth1.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Eyouth1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(5);
            });

            builder.Services.AddDbContext<CompanyCtx>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("con"));
            });

            //builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            //builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();    
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric=false;   
                
            }).AddEntityFrameworkStores<CompanyCtx>();

            builder.Services.AddSignalR();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();  //short-Circiut

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();//username & pass
            app.UseAuthorization();//Roles

            app.MapHub<ChatHub>("/Chat");
            app.MapControllerRoute(
                name: "myRoute",
                pattern: "app/{controller=Employee}/{action=Index}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
            //Add roles to DB
            var scope=app.Services.CreateScope();
            var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (roleMgr.Roles.Count()== 0)
            {
                var roles = new List<IdentityRole>
                {
                    new IdentityRole("Admin"),
                    new IdentityRole("Moderator"),
                    new IdentityRole("User")
                };

                foreach (var role in roles)
                {
                    roleMgr.CreateAsync(role).Wait();
                }
            }

            app.Run();
        }
    }
}
