using BogusProperGenderEntityWeb.Classes;
using BogusProperGenderEntityLib.Data;
using Microsoft.EntityFrameworkCore;
using ConsoleConfigurationLibrary.Classes;
using EntityCoreFileLogger;

namespace BogusProperGenderEntityWeb;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();


        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(AppConnections.Instance.MainConnection)))
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextToFileLogger().Log, new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information));
        
        var app = builder.Build();


        if (!app.Environment.IsDevelopment())
        {
            SetupLogging.Production();
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        else
        {
            SetupLogging.Development();
        }


        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }


}


