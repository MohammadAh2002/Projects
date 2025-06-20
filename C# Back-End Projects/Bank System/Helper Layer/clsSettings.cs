
using Microsoft.Extensions.Configuration;

namespace Helper_Layer
{
    public static class clsSettings
    {
        private static readonly IConfigurationRoot Connectionconfiguration = new ConfigurationBuilder()
         .SetBasePath(AppContext.BaseDirectory)
         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
         .Build();

        public static string? DatabaseConnection => Connectionconfiguration.GetConnectionString("DefaultConnection");
    }
}
