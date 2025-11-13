using Microsoft.Extensions.Configuration;

namespace Solution.DekstopApp.Configurations
{
    public static class ConfigureAppVariables
    {
        public static MauiAppBuilder UseAppConfigurations(this MauiAppBuilder builder)
        {
#if DEBUG
            var file = "appsettings.Development.json";
#else
            var file = "appsettings.Production.json";
#endif

            var stream = new MemoryStream(File.ReadAllBytes($"{file}"));

            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();


            builder.Configuration.AddConfiguration(config);

            return builder;
        }
    }
}
