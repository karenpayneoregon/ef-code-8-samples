using EF_Core_MaskingSample.Data;
using EF_Core_MaskingSample1.Classes;
using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EF_Core_MaskingSample1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                   .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
                   .MinimumLevel.Information()
                   .WriteTo.Console()
                   .CreateLogger();

        builder.Host.UseSerilog();


        builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
                .LogTo(new DbContextToFileLogger().Log,
                    [DbLoggerCategory.Database.Command.Name],
                    LogLevel.Information));

        builder.Services.AddDataProtection();
        builder.Services.AddScoped<EncryptionService>();
        builder.Services.AddScoped<PersonService>();

        builder.Services.AddRazorPages();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
