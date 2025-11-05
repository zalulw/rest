namespace Solution.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
    DbSet<AccountEntity> Accounts { get; set; }

    DbSet<InvoiceItemEntity> InvoiceItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
