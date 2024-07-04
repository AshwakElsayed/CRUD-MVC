using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieStore_MVC.Models.Domain;
using MovieStore_MVC.Repositories.Implementation;
using MovieStore_MVC.Repositories.Interfaces;
using MovieStoreMvc.Repositories.Implementation;

namespace MovieStore_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUserAuthServices, UserAuthService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IFileServise, FileService>();
            builder.Services.AddScoped<IMovieService, MovieService>();


            builder.Services.AddDbContext<DatabaseContext>(options=> 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // for identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            //builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}