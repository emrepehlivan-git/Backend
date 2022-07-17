using Microsoft.Extensions.Configuration;

namespace Persistence.Configurations
{
    static class GetConnStrings
    {
        public static string ConnectionStrings
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/WebApi"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("StoreDb");
            }
        }
    }
}
