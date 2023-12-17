using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TyeBank.Business;
using TyeBank.DataAccess;
using TyeBank.Interfaces;
using TyeBank.Models.AppDbContext;
using Microsoft.Extensions.Configuration;


namespace TyeBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<ILoginBusiness, LoginBusiness>();
            builder.Services.AddScoped<ILoginDataAccess, LoginDataAccess>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();




            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
