using System.Text.Json.Serialization;

namespace Solution.Core.Models;

public partial class BillModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("accountNumber")]
    private string accountNumber;

    [ObservableProperty]
    [JsonPropertyName("invoiceDate")]
    private DateTime invoiceDate;

    public BillModel()
    {

    }

    public BillModel(BillEntity entity)
    {
        this.Id = entity.Id;
        this.AccountNumber = entity.AccountNumber;
        this.InvoiceDate = entity.InvoiceDate;
    }

    public BillEntity ToEntity()
    {
        return new BillEntity
        {
            Id = this.Id,
            AccountNumber = this.AccountNumber,
            InvoiceDate = this.InvoiceDate
        };
    }

    public void ToEntity(BillEntity entity)
    {
        entity.Id = this.Id;
        entity.AccountNumber = this.AccountNumber;
        entity.InvoiceDate = this.InvoiceDate;
    }
}
