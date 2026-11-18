using Microsoft.Extensions.Configuration;

namespace HasConversion_Bool_ColorApp.Classes.Core
{
    /// <summary>
    /// Performs data operations.
    /// </summary>
    internal class DataOperations
    {
        public static IConfigurationBuilder ConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }
    }
}
