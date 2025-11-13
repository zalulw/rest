using FluentValidation;

namespace Solution.DekstopApp.Configurations
{
    public static class ConfigureDI
    {
        public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
        {
            //builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();

            
            return builder;
        }
    }
}
