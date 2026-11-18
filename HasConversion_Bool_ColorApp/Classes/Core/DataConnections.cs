using Microsoft.Extensions.Configuration;

namespace HasConversion_Bool_ColorApp.Classes.Core
{
#nullable disable
    /// <summary>
    /// Represents a singleton class that provides access to known database connection strings.
    /// </summary>
    /// <remarks>
    /// This class is responsible for loading and managing connection strings from the application's configuration file.
    /// It ensures that the connection strings are accessible throughout the application via a single instance.
    /// </remarks>
    public sealed class DataConnections
    {
        private static readonly Lazy<DataConnections> Lazy = new(() => new DataConnections());
        public static DataConnections Instance => Lazy.Value;

        /// <summary>
        /// Gets the connection string for the database.
        /// </summary>
        public string MainConnection { get; set; }

        public static IConfigurationRoot Configuration { get; private set; }
        private DataConnections()
        {

            Configuration = DataOperations.ConfigurationBuilder().Build();
            MainConnection = Configuration.GetConnectionString("MainConnection");
        }
    }
}