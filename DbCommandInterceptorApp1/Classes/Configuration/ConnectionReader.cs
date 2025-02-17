using Microsoft.Extensions.Configuration;

namespace DbCommandInterceptorApp1.Classes.Configuration
{
    public class ConnectionReader
    {
        private static IConfiguration _configuration;

        public static string GetMainConnectionString()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            return _configuration.GetConnectionString();
        }
    }

}
