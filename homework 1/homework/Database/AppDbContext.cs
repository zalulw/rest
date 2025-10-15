namespace Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options))
{
    public DbSet<OpEntity> Operators { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

}
