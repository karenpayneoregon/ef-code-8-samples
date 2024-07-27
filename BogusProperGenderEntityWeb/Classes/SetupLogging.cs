using BogusProperGenderEntityLib.Models;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using static System.DateTime;

namespace BogusProperGenderEntityWeb.Classes;

/// <summary>
/// Class responsible for setting up logging configurations.
/// </summary>
/// <remarks>
/// Under Development method, we use the destructure.
/// ByTransforming method to preserve the object structure.
/// https://github.com/serilog/serilog/wiki/Structured-Data#preserving-object-structure
/// </remarks>
public class SetupLogging
{
    /// <summary>
    /// Sets up logging configurations for development environment.
    ///
    /// Setup to deconstruct the BirthDays object like a DTO
    /// https://github.com/serilog/serilog/wiki/Structured-Data#preserving-object-structure
    /// </summary>
    public static void Development()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Destructure.ByTransforming<BirthDays>(
                bd => new
                {
                    Name = bd.FirstName, 
                    Last = bd.LastName, 
                    Birth = bd.BirthDate, 
                    Gender = bd.Gender
                })
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            // Shares same folder as for EF Core logs
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "LogFiles", $"{Now.Year}-{Now.Month:D2}-{Now.Day:D2}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }

    /// <summary>
    /// Sets up logging configurations for staging environment.
    /// </summary>
    public static void Staging()
    {
        // TODO
    }

    /// <summary>
    /// Sets up logging configurations for production environment.
    /// </summary>
    public static void Production()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", "Log.txt"),
                rollingInterval: RollingInterval.Day)
            .CreateBootstrapLogger();
    }
}
