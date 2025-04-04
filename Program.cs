using Eyouth1.Models;
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();  //short-Circiut

            app.UseSession();

            app.UseRouting();

            //app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            

            app.Run();
        }
    }
}
