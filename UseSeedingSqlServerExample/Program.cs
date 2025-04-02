using Microsoft.EntityFrameworkCore;
using UseSeedingSqlServerExample.Classes;
using UseSeedingSqlServerExample.Data;
using UseSeedingSqlServerExample.Models;

namespace UseSeedingSqlServerExample;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        SetupLogging.Development();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<CarDbContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();

            var shouldSeed = configuration.GetValue<bool>("Database:SeedDataEnabled");

            options.UseSqlServer(connectionString);

            if ((environment.IsDevelopment() || environment.IsStaging()) && shouldSeed)
            {
                options.UseSeeding((context, _) =>
                {
                    Console.WriteLine("🚗 Running sync seeding...");

                    var demoCar = context.Set<Car>().FirstOrDefault(b => b.Id == 2);
                    if (demoCar == null)
                    {
                        context.Set<Car>().Add(new Car { Make = "Tesla", Model = "Model S", YearOf = 2025});
                        context.SaveChanges();
                    }
                });

                options.UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    Console.WriteLine("🚗 Running async seeding...");

                    var demoCar = await context.Set<Car>().FirstOrDefaultAsync(b => b.Id == 2, cancellationToken);
                    if (demoCar == null)
                    {
                        context.Set<Car>().Add(new Car { Make = "Tesla", Model = "Model S", YearOf = 2025 });
                        await context.SaveChangesAsync(cancellationToken);
                    }
                });
            }
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        // Run EF Core migrations to trigger UseSeeding
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<CarDbContext>();
            db.Database.EnsureCreated(); // required to run UseSeeding
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
