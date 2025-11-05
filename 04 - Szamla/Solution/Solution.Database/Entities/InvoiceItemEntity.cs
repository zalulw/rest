namespace Solution.Database.Entities;

[Table("InvoiceItem")]
public class InvoiceItemEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("Account")]
    public int AccountNumber { get; set; }
    public virtual AccountEntity Account { get; set; }

    [Required]
    public string Appelation { get; set; }

    [Required]
    public double UnitPrice { get; set; }

    [Required]
    public int UnitQuantity { get; set; }
}
