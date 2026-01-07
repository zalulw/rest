using Solution.Database.Entities;

namespace Solution.Services.Account.Model;

public partial class AccountModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("account_number")]
    private string accountnumber;

    [ObservableProperty]
    [JsonPropertyName("invoice_date")]
    private DateTime invoicedate;

    public AccountModel() { }

    public AccountModel(AccountEntity entity)
    {
        this.Accountnumber = entity.AccountNumber;
        this.Invoicedate = entity.InvoiceDate;
    }

    public AccountEntity ToEntity()
    {
        return new AccountEntity
        {
            AccountNumber = this.Accountnumber,
            InvoiceDate = this.Invoicedate
        };
    }

    public void ToEntity(AccountEntity entity)
    {
        entity.AccountNumber = this.accountnumber;
        entity.InvoiceDate = this.invoicedate;
    }
}
