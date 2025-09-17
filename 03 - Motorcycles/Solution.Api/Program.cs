using Solution.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.LoadAppSettings()
       .ConfigureDatabase();


builder.Services.AddControllers();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
