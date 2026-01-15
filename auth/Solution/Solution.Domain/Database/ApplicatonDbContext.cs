

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Solution.Domain.Database;

public sealed class ApplicatonDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>,  Guid>
{
    public override DbSet<UserEntity> Users { get; set; }

    public ApplicatonDbContext(DbContextOptions<ApplicatonDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureUser();
    }
}
