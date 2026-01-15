namespace Solution.Domain.Database.Entities;

public class UserEntity : IdentityUser<Guid>
{
    public string FullName { get; set; }

    public DateTime RegistratedAtUtc { get; set; } = DateTime.UtcNow;
}
