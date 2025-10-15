namespace DesktopApp.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainView>();

        builder.Services.AddTransient<OpListViewModel>();
        builder.Services.AddTransient<OpListView>();
        builder.Services.AddTransient<CreateEditOpViewModel>();
        builder.Services.AddTransient<CreateEditOpView>();
        builder.Services.AddTransient<IOpService, OpService>();


        builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();


        return builder;
    }
}
