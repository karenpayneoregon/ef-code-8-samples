namespace UseSeedingSqlServerExample.Models;

public class AppSettings
{
    /// <summary>
    /// Gets the configuration key used to determine whether seeding of initial data is enabled in the database.
    /// </summary>
    /// <remarks>
    /// This property provides a static string representing the configuration key 
    /// "Database:SeedDataEnabled", which can be used to retrieve a boolean value 
    /// from the application's configuration settings. This value is typically used 
    /// to enable or disable database seeding during application startup.
    /// </remarks>
    public static string SeedDataEnabled => "Database:SeedDataEnabled";
}
