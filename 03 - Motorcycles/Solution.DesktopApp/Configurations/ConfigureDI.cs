namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MotorcycleListViewModel>();
        builder.Services.AddTransient<CreateOrEditMotorcycleViewModel>();
        builder.Services.AddTransient<ModifyManufacturerViewModel>();
        builder.Services.AddTransient<ModifyTypeViewModel>();


        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<MotorcycleListView>();
        builder.Services.AddTransient<CreateOrEditMotorcycleView>();
        builder.Services.AddTransient<ModifyManufacturerView>();
        builder.Services.AddTransient<ModifyTypeView>();



        builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();
        builder.Services.AddTransient<IMotorcycleService, MotorcycleService>();

        return builder;
    }
}
