﻿using Microsoft.EntityFrameworkCore;
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


        builder.Services.AddDbContext<CarDbContext>((serviceProvider, options) =>
        {

            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            var shouldSeed = configuration.GetValue<bool>(AppSettings.SeedDataEnabled);
            
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.CommandTimeout(5));

            if ((environment.IsDevelopment() || environment.IsStaging()) && shouldSeed)
            {
                options.UseAsyncSeeding(async (context, _, cancellationToken) =>
                {

                    if (!await context.Set<Car>().AnyAsync(c => c.Id == 1, cancellationToken))
                    {
                        await context.Set<Car>().AddAsync(new Car { Make = "Mazda", Model = "Miata", YearOf = 2025}, cancellationToken);
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

        // Trigger to run UseAsyncSeeding()
        using (var scope = app.Services.CreateScope())
        {
            // Create a scope to obtain a reference to the database context (CarDbContext)
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
