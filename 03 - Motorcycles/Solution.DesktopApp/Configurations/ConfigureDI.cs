namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
	public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MotorcycleListViewModel>();
        builder.Services.AddTransient<CreateOrEditMotorcycleViewModel>();
        builder.Services.AddTransient<CreateManufacturerViewModel>();
        builder.Services.AddTransient<ManufacturerListViewModel>();
        builder.Services.AddTransient<CreateTypeViewModel>();
        builder.Services.AddTransient<TypeListViewModel>();

        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<MotorcycleListView>();
        builder.Services.AddTransient<CreateOrEditMotorcycleView>();
        builder.Services.AddTransient<CreateManufacturerView>();
        builder.Services.AddTransient<ManufacturerListView>();
        builder.Services.AddTransient<CreateTypeView>();
        builder.Services.AddTransient<TypeListView>();  

        builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService> ();
        builder.Services.AddTransient<IMotorcycleService, MotorcycleService>();
        builder.Services.AddTransient<IManufacturerService, ManufacturerService>();
        builder.Services.AddTransient<ITypeService, TypeService>();

        return builder;
	}
}
