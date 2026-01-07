using Solution.Services;
using Solution.Services.Account.Interfaces;
using Solution.Services.InvoiceItem.Interfaces;


namespace Solution.Api.Configurations;

public static class DIConfiguration
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAccountService, AccountService>();
        builder.Services.AddTransient<IInvoiceItemService, InvoiceItemService>();
        builder.Services.AddHttpContextAccessor();
        return builder; 
    }
}
