using Microsoft.EntityFrameworkCore;
using Solution.Core.Models;

namespace Bills.Services;
public class ItemService(AppDbContext dbContext) : IBillItemsService
{
    public async Task<ErrorOr<BillItemModel>> CreateAsync(BillItemModel billItem)
    {
        var newItem = billItem.ToEntity();

        await dbContext.BillItems.AddAsync(newItem);
        await dbContext.SaveChangesAsync();

        return new BillItemModel(newItem);
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int id)
    {
        var result = await dbContext.BillItems.AsNoTracking()
                                          .Where(x => x.Id == id)
                                          .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<List<BillItemModel>>> GetAllAsync() => await dbContext.BillItems.Select(x => new BillItemModel(x))
                                                                                      .ToListAsync();


    public async Task<ErrorOr<BillItemModel>> GetByIdAsync(int id)
    {
        var item = await dbContext.BillItems.FirstOrDefaultAsync(x => x.Id == id);
        if (item is null)
        {
            return Error.NotFound(description: "Item not found!");
        }
        return new BillItemModel(item);
    }

    public Task<ErrorOr<PaginationModel<BillItemModel>>> GetPagedAsync(int page = 0)
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<Success>> UpdateAsync(BillItemModel billItem)
    {
        var result = await dbContext.BillItems.AsNoTracking()
                                          .Where(x => x.Id == billItem.Id)
                                          .ExecuteUpdateAsync(x => x.SetProperty(p => p.Designation, billItem.Designation)
                                                                    .SetProperty(p => p.UnitPrice, billItem.UnitPrice)
                                                                    .SetProperty(p => p.Amount, billItem.Amount));
        return result > 0 ? Result.Success : Error.NotFound();
    }

}