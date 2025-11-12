using Solution.Services.Account.Interfaces;
using Solution.Services.Account.Model;

namespace Solution.Services;

public class AccountService(AppDbContext dbContext) : IAccountService
{
    public async Task<ErrorOr<AccountModel>> CreateAsync(AccountModel model)
    {
        bool exists = await dbContext.Accounts.AnyAsync(a => a.AccountNumber == model.Accountnumber);
        if (exists)
        {
            return Error.Conflict(description: "Account already exists");
        }
        var account = model.ToEntity();

        await dbContext.Accounts.AddAsync(account);
        await dbContext.SaveChangesAsync();

        return model;
    }

    public async Task<ErrorOr<Success>> UpdateAsync(AccountModel model)
    {
        var result = await dbContext.Accounts.AsNoTracking()
                                             .Where(a => a.AccountNumber == model.Accountnumber)
                                             .ExecuteUpdateAsync(a => a.SetProperty(p => p.InvoiceDate, model.Invoicedate));
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int accountNumber)
    {
        var result = await dbContext.Accounts.AsNoTracking()
                                             .Where(a => a.AccountNumber == accountNumber)
                                             .ExecuteDeleteAsync();
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<AccountModel>> GetByIdAsync(int accountNumber)
    {
        var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        if (account is null)
        {
            return Error.NotFound(description: "Account not found");
        }
        return new AccountModel(account);
    }

    public async Task<ErrorOr<List<AccountModel>>> GetAllAsync() =>
        await dbContext.Accounts.AsNoTracking()
                                 .Select(a => new AccountModel(a))
                                 .ToListAsync();
}
