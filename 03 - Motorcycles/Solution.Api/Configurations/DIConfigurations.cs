﻿namespace Solution.Api.Configurations;

public static class DIConfigurations
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddTransient<IValidatorInterceptor, FluentvalidationInterceptor>();

        builder.Services.AddTransient<IMotorcycleService, MotorcycleService>();

        return builder;
    }

}
