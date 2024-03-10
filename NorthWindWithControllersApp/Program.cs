using Microsoft.EntityFrameworkCore;
using NorthWindWithControllersApp.Classes;
using NorthWindWithControllersApp.Data;

namespace NorthWindWithControllersApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        
        
        builder.Services.AddControllersWithViews();


        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
        SetupLogging.Development();
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

        //app.MapControllerRoute(name: "default", pattern: "{controller=Customers}/{action=Index}");

        app.MapDefaultControllerRoute();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
