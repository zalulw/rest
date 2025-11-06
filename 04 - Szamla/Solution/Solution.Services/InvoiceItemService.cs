namespace Solution.Services;

public class InvoiceItemService(AppDbContext dbContext) : IInvoiceItemService
{
    private const int ROW_COUNT = 20;

    public async Task<ErrorOr<InvoiceItemModel>> CreateAsync(InvoiceItemModel model)
    {
        bool exists = await dbContext.InvoiceItems.AnyAsync(i => i.Account.AccountNumber == model.Accountnumber &&
                                                                 i.Appelation == model.Appelation);

        if (exists)
        {
            return Error.Conflict(description: "Invoice item already exists");
        }

        var item = model.ToEntity();

        await dbContext.InvoiceItems.AddAsync(item);
        await dbContext.SaveChangesAsync();

        return model;

    }

    public async Task<ErrorOr<Success>> UpdateAsync(InvoiceItemModel model)
    {
        var result = await dbContext.InvoiceItems.AsNoTracking()
                                                 .Where(i => i.Id == model.Id)
                                                 .ExecuteUpdateAsync(i => i.SetProperty(p => p.Appelation, model.Appelation)
                                                                           .SetProperty(p => p.UnitPrice, model.Unitprice)
                                                                           .SetProperty(p => p.UnitQuantity, model.Unitquantity)
                                                                           .SetProperty(p => p.AccountNumber, model.Accountnumber)
                                                                           );

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int id)
    {
        var result = await dbContext.InvoiceItems.AsNoTracking().Include(i => i.AccountNumber).Where(i => i.Id == id).ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<List<InvoiceItemModel>>> GetAllAsync() => await dbContext.InvoiceItems.AsNoTracking().Select(i => new InvoiceItemModel(i)).ToListAsync();

    public async Task<ErrorOr<InvoiceItemModel>> GetByIdAsync(int id)
    {
        var item = await dbContext.InvoiceItems.FirstOrDefaultAsync(i => i.Id == id);

        if (item is null)
        {
            return Error.NotFound(description: "Invoice item not found");
        }

        return new InvoiceItemModel(item);
    }

    public async Task<ErrorOr<PaginationModel<InvoiceItemModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var items = await dbContext.InvoiceItems.AsNoTracking()
                                                .Skip(page * ROW_COUNT)
                                                .Take(ROW_COUNT)
                                                .Select(i => new InvoiceItemModel(i))
                                                .ToListAsync();

        var paginationModel = new PaginationModel<InvoiceItemModel>
        {
            Items = items,
            Count = await dbContext.InvoiceItems.CountAsync()
        };

        return paginationModel;
    }
}
