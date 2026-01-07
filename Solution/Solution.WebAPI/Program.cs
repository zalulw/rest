var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.ConfigureDatabase()
       .LoadEnvironmentVariables();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();
