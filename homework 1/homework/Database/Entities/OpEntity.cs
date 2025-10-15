namespace Database.Entities;

[Table("Operator")]
public class OpEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public int Id { get; set; }

    [StringLength(128)]
    public string? ImageId { get; set; }

    [StringLength(128)]
    [Required]
    public string PublicId { get; set; }

    [StringLength(128)]
    [Required]
    public string Name { get; set; }
}
