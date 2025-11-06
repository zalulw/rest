using Solution.Database.Entities;

namespace Solution.Services.Account.Model;

public partial class AccountModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("account_number")]
    private int accountnumber;

    [ObservableProperty]
    [JsonPropertyName("invoice_date")]
    private DateTime invoicedate;

    public AccountModel() { }

    public AccountModel(AccountEntity entity)
    {
        this.Accountnumber = entity.AccountNumber;
        this.Invoicedate = entity.InvoiceDate;
    }

    public AccountModel ToEntity()
    {
        return new AccountModel
        {
            Accountnumber = this.Accountnumber,
            Invoicedate = this.Invoicedate
        };
    }

    public void ToEntity(AccountEntity entity)
    {
        entity.AccountNumber = this.Accountnumber;
        entity.InvoiceDate = this.Invoicedate;
    }
}
