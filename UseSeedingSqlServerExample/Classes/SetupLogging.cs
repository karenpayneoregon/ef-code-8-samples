using Serilog;
using Serilog.Events;
using SeriLogThemesLibrary;

namespace UseSeedingSqlServerExample.Classes;

/// <summary>
/// Provides functionality to configure logging using Serilog for the application.
/// </summary>
/// <remarks>
/// This class is designed to encapsulate the setup of Serilog logging, ensuring that the 
/// <c>Program.Main</c> method remains clean and maintainable. It allows the logging configuration 
/// to be easily reused across multiple projects.
/// </remarks>
public class SetupLogging
{
    /// <summary>
    /// Configures the Serilog logger for development environments.
    /// </summary>
    /// <remarks>
    /// This method sets up the Serilog logger with a default theme and a minimum log level override for Microsoft logs.
    /// It is intended to be used in development scenarios to provide structured logging output to the console.
    /// </remarks>
    public static void Development()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .WriteTo.Console(theme: SeriLogCustomThemes.Default())
            .CreateLogger();
    }
}


