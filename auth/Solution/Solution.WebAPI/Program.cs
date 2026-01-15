var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.LoadEnvironmentVariables()
       .ConfigureDI()
       .LoadSettings()
       .UseSecurity()
       .UseIdentity()
       .UseScalarOpenApi()
       .ConfigureDatabase();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseSecurity();
app.MapControllers();
app.UseScalarOpenApi();

await app.RunAsync();
