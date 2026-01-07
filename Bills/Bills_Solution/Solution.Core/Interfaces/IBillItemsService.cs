namespace Solution.Core.Interfaces;

public interface IBillItemsService
{
    Task<ErrorOr<BillItemModel>> CreateAsync(BillItemModel billItemModel);
    Task<ErrorOr<Success>> UpdateAsync(BillItemModel billItemModel);
    Task<ErrorOr<Success>> DeleteAsync(int billItemId);
    Task<ErrorOr<BillItemModel>> GetByIdAsync(int billItemId);
    Task<ErrorOr<List<BillItemModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<BillItemModel>>> GetPagedAsync(int page = 0);
}
