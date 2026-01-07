namespace Solution.Database.Entities;

[Table("InvoiceItem")]
public class InvoiceItemEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string AccountNumber { get; set; }

    [Required]
    public string Appelation { get; set; }

    [Required]
    public double UnitPrice { get; set; }

    [Required]
    public int UnitQuantity { get; set; }

}
