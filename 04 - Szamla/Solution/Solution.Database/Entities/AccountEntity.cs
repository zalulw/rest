namespace Solution.Database.Entities;

[Table("Account")]
public class AccountEntity 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int AccountNumber { get; set; }

    [Required]
    public DateTime InvoiceDate { get; set; }

    public virtual ICollection<InvoiceItemEntity> InvoiceItems { get; set; };
}
