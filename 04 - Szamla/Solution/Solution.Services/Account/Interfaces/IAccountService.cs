using Solution.Services.Account.Model;

namespace Solution.Services.Account.Interfaces
{
    public interface IAccountService
    {
        Task<ErrorOr<AccountModel>> CreateAsync(AccountModel model);
        Task<ErrorOr<Success>> UpdateAsync(AccountModel model);
        Task<ErrorOr<Success>> DeleteAsync(int accountNumber);
        Task<ErrorOr<AccountModel>> GetByIdAsync(int accountNumber);
        Task<ErrorOr<List<AccountModel>>> GetAllAsync();
    }
}
