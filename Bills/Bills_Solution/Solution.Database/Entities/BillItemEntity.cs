namespace Solution.Database.Entities;

[Table("Item")]
public class BillItemEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(128)]
    [Required]
    public string Designation { get; set; }

    [Required]
    public int UnitPrice { get; set; }

    [Required]
    public int Amount { get; set; }

    [ForeignKey("Bill")]
    public int BillId { get; set; }

    public virtual BillEntity Bill { get; set; }
}
