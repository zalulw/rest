﻿namespace Solution.Database.Entities;

[Table("Motorcycle")]
public class MotorcycleEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [StringLength(128)]
    [Required]
    public string PublicId { get; set; }

    [StringLength(128)]
    public string? ImageId { get; set; }

    [StringLength(512)]
    public string? WebContentLink { get; set; }

    [StringLength(128)]
    [Required]
    public string Model {  get; set; }

    [Required]
    public uint Cubic {  get; set; }

    [Required]
    public uint ReleaseYear { get; set; }

    [Required]
    public uint Cylinders { get; set; }

    [ForeignKey("Manufacturer")]
    public uint ManufacturerId { get; set; }
    public virtual ManufacturerEntity Manufacturer { get; set; }

    [ForeignKey("Type")]
    public uint TypeId { get; set; }

    public virtual MotorcycleTypeEntity Type { get; set; }
}
