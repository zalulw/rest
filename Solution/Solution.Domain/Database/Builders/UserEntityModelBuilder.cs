using System.Runtime.CompilerServices;

namespace Solution.Domain.Database.Builders;

internal static class UserEntityModelBuilder
{
    public static void ConfigureUser(this ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.Id).IsUnique();

            entity.Property(e => e.FullName).HasColumnName("FullName")
                                            .HasMaxLength(255)
                                            .IsRequired();
            
            entity.Property(e => e.RegisteredAtUtc).HasColumnName("RegisteredAt")
                                                   .IsRequired(); 
        });
    }
}
