using Microsoft.AspNetCore.Builder;

namespace Solution.DesktopApp.Configurations;

public static class ConfigureSQLServer
{
    public static MauiAppBuilder UseMsSqlServer(this MauiAppBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseLazyLoadingProxies()
                .UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(Solution.Database.AssemblyReference.Assembly);
                    sqlOptions.EnableRetryOnFailure();
                    sqlOptions.CommandTimeout(300);
                }));


        return builder;
    }
}

