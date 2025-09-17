namespace Solution.Api.Configurations;

public static class DIConfigurations
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IMotorcycleService, MotorcycleService>();
        builder.Services.AddTransient<IGoogleDriveService, GoogleDriveService>();
        builder.Services.AddHttpContextAccessor();

        return builder;
    }

}
