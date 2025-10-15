namespace homework.Configs
{
    public static class DbConfig
    {
        public static WebApplicationBuilder ConfigDb(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseLazyLoadingProxies()
                   .UseSqlServer(connectionString, options =>
                   {
                       options.MigrationsAssembly(Solution.Database.AssemblyReference.Assembly);
                       options.EnablyRetryOnFailure();
                       options.CommandTimeout(300);
                   }));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            return builder;
        }
    }
}
