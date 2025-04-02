using Microsoft.EntityFrameworkCore;
using UseSeedingSqlServerExample.Classes;
using UseSeedingSqlServerExample.Data;
using UseSeedingSqlServerExample.Models;

namespace UseSeedingSqlServerExample;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        SetupLogging.Development();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<CarDbContext>((serviceProvider, options) =>
        {

            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            var shouldSeed = configuration.GetValue<bool>(AppSettings.SeedDataEnabled);

            options.UseSqlServer(connectionString);

            if ((environment.IsDevelopment() || environment.IsStaging()) && shouldSeed)
            {
                options.UseAsyncSeeding(async (context, _, cancellationToken) =>
                {

                    var exists = await context.Set<Car>().AnyAsync(c => c.Id == 2, cancellationToken);
                    if (!exists)
                    {
                        context.Set<Car>().Add(new Car { Make = "Tesla", Model = "Model S", YearOf = 2025});
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    //var exists2 = await context.Set<Car>().AnyAsync(c => c.Id == 2, cancellationToken);
                    //if (!exists2)
                    //{
                    //    context.Set<Car>().Add(new Car { Make = "Ford", Model = "Mustang Mach-E" });
                    //    await context.SaveChangesAsync(cancellationToken);
                    //}
                });
            }
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        // Trigger EF Core to run UseAsyncSeeding()
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<CarDbContext>();
            await db.Database.EnsureCreatedAsync(); // Will trigger UseAsyncSeeding
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        await app.RunAsync();
    }
}
