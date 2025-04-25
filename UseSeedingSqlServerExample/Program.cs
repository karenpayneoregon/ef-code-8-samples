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
        bool shouldSeed = builder.Configuration.GetValue<bool>(AppSettings.SeedDataEnabled);
        builder.Services.AddRazorPages();

        SetupLogging.Development();

        builder.Services.AddDbContext<Context>((serviceProvider, options) =>
        {

            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();

            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions =>
                {
                    sqlOptions.CommandTimeout(5);
                }).LogTo(Console.WriteLine, LogLevel.Information);

            if ((environment.IsDevelopment() || environment.IsStaging()) && shouldSeed)
            {
                options.UseAsyncSeeding(async (context, _, cancellationToken) =>
                {

                    if (context.ShouldSeed<Manufacturer>())
                    {
                        await context.Set<Manufacturer>().AddRangeAsync(MockedData.GetManufacturers(), cancellationToken);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                    if (context.ShouldSeed<Car>())
                    {
                        await context.Set<Car>().AddRangeAsync(MockedData.GetCars(), cancellationToken);
                        await context.SaveChangesAsync(cancellationToken);
                    }

                });

                options.UseSeeding((context, _) =>
                {
                    if (context.ShouldSeed<Manufacturer>())
                    {
                        context.Set<Manufacturer>().AddRange(MockedData.GetManufacturers());
                        context.SaveChanges();
                    }

                    if (context.ShouldSeed<Car>())
                    {
                        context.Set<Car>().AddRange(MockedData.GetCars());
                        context.SaveChanges();
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

        // Trigger to run UseAsyncSeeding()
        if (shouldSeed)
        {
            using var scope = app.Services.CreateScope();
            // Create a scope to obtain a reference to the database context (Context)
            var db = scope.ServiceProvider.GetRequiredService<Context>();
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