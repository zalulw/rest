using Solution.Services.Account.Model;

namespace Solution.Services.Account.Interfaces
{
    public interface IAccountService
    {
        Task<ErrorOr<AccountModel>> CreateAsync(AccountModel model);
        Task<ErrorOr<Success>> UpdateAsync(AccountModel model);
        Task<ErrorOr<Success>> DeleteAsync(string accountNumber);
        Task<ErrorOr<AccountModel>> GetByIdAsync(string accountNumber);
        Task<ErrorOr<List<AccountModel>>> GetAllAsync();
        Task<ErrorOr<List<AccountModel>>> GetPagedAsync(int pageNumber);
    }
}
