using Solution.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.LoadAppSettings()
       .ConfigureDI()
       .ConfigureDatabase()
       .ConfigureFluentValidation();


builder.Services.AddControllers();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
