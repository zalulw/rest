using Microsoft.EntityFrameworkCore;

namespace Solution.Services;

public class BillService(AppDbContext dbContext) : IBillService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<BillModel>> CreateAsync(BillModel model)
    {
        bool exists = await dbContext.Bills.AnyAsync(x => x.Id == model.Id &&
                                                          x.InvoiceDate == model.InvoiceDate &&
                                                          x.AccountNumber == model.AccountNumber)

        if (exists)
        {
            return Error.Conflict(description: "Bill already exists");
        }

        var bill = model.ToEntity();

        await dbContext.Bills.AddAsync(bill);
        await dbContext.SaveChangesAsync();
        return new BillModel(bill);
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int billId)
    {
        var result = await dbContext.Bills.AsNoTracking()
                                          .Include(x => x.Items)
                                          .Where(x => x.Id == billId)
                                          .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<List<BillModel>>> GetAllAsync() => 
        await dbContext.Bills.AsNoTracking()
                             .Include(x => x.Items)
                             .Select(x => new BillModel(x))
                             .ToListAsync();

    public async Task<ErrorOr<BillModel>> GetByIdAsync(int billId)
    {
        var bill = await dbContext.Bills.Include(x => x.Items)
                                        .FirstOrDefaultAsync(x => x.Id == billId);

        if(bill is null)
        {
            return Error.NotFound(description: "Bill not found");
        }

        return new BillModel(bill);
    }

    public async Task<ErrorOr<PaginationModel<BillModel>>> GetPagedAsync(int page = 0)
    {
        page = page < 0 ? 0 : page - 1;

        var bills = await dbContext.Bills.AsNoTracking()
                                         .Include(x => x.Items)
                                         .Skip(page * ROW_COUNT)
                                         .Take(ROW_COUNT)
                                         .Select(x => new BillModel(x))
                                         .ToListAsync();

        var paginationModel = new PaginationModel<BillModel>
        {
            Items = bills,
            Count = await dbContext.Bills.CountAsync(),
        };

        return paginationModel;
    }

    public async Task<ErrorOr<Success>> UpdateAsync(BillModel model)
    {
        var result = await dbContext.Bills.AsNoTracking()
                                          .Where(x => x.Id == model.Id)
                                            .ExecuteUpdateAsync(x => x
                                                .SetProperty(b => b.AccountNumber, model.AccountNumber)
                                                .SetProperty(b => b.InvoiceDate, model.InvoiceDate));

        return result > 0 ? Result.Success : Error.NotFound();

    }
}
