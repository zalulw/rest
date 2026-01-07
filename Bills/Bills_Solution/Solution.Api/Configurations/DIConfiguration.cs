using Solution.Core.Interfaces;
using Solution.Services;
using Bills.Services;


namespace Solution.Api.Configurations;

public static class DIConfiguration
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IBillService, BillService>();
        builder.Services.AddTransient<IBillItemsService, ItemService>();
        builder.Services.AddHttpContextAccessor();
        return builder; 
    }
}
