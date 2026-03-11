using Microsoft.EntityFrameworkCore;
using Solution.Database;
using Solution.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=HeroWarsDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
builder.Services.AddScoped<IHeroService, HeroService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
