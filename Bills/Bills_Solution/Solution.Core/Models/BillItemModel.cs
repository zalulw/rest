namespace Solution.Core.Models;

public partial class BillItemModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("designation")]
    private string designation;

    [ObservableProperty]
    [JsonPropertyName("unitPrice")]
    private int unitPrice;

    [ObservableProperty]
    [JsonPropertyName("amount")]
    private int amount;

    public BillItemModel()
    {
    }

    public BillItemModel(BillItemEntity entity)
    {
        this.Id = entity.Id;
        this.Designation = entity.Designation;
        this.UnitPrice = entity.UnitPrice;
        this.Amount = entity.Amount;
    }

    public BillItemEntity ToEntity()
    {
        return new BillItemEntity
        {
            Id = this.Id,
            Designation = this.Designation,
            UnitPrice = this.UnitPrice,
            Amount = this.Amount
        };
    }

    public void ToEntity(BillItemEntity entity)
    {
        entity.Id = this.Id;
        entity.Designation = this.Designation;
        entity.UnitPrice = this.UnitPrice;
        entity.Amount = this.Amount;
    }
}
