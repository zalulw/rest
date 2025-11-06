using Solution.Services;
using Solution.Services.InvoiceItem.Interfaces;

namespace Solution.Api.Configurations;

public static class DIConfigurations
{
    public static WebApplicationBuilder ConfigureDI (this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddTransient<IInvoiceItemService, InvoiceItemService>();

        return builder;
    }
}
