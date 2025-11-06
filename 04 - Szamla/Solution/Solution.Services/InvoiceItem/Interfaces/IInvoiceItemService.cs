namespace Solution.Services.InvoiceItem.Interfaces
{
    public interface IInvoiceItemService
    {
        Task<ErrorOr<InvoiceItemModel>> CreateAsync(InvoiceItemModel model);

        Task<ErrorOr<Success>> UpdateAsync(InvoiceItemModel model);

        Task<ErrorOr<Success>> DeleteAsync(int id);

        Task<ErrorOr<InvoiceItemModel>> GetByIdAsync(int id);

        Task<ErrorOr<List<InvoiceItemModel>>> GetAllAsync();

        Task<ErrorOr<PaginationModel<InvoiceItemModel>>> GetPagedAsync(int page = 0);
    }
}