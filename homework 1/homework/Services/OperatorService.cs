using Core.Models;
using Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services;

public class OperatorService(AppDbContext dbContext) : IOpService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<OpModel>> CreateAsync(OpModel model)
    {
        bool exists = await dbContext.Operators.AnyAsync(o => o.name == model.name);

        if (exists)
        {
            return Error.Conflict(description: 'Operator already exists');
        }

        var op = model.ToEntity();
        op.PublicId = Guid.NewGuid().ToString();

        await dbContext.Operators.AddAsync(op);
        await dbContext.SaveChangesAsync();

        model.Id = op.PublicId;

        return model;
    }

    public async Task<ErrorOr<Success>> DeleteAsync(string opId)
    {
        var result = await dbContext.Operators.AsNoTracking().Where(o => o.PublicId == opId).ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound(description: 'Operator not found');
    }

    public async Task<ErrorOr<OpModel>> GetByIdAsync(string opId)
    {
        var op = await dbContext.Operators.FirstOrDefaultAsync(o => o.PublicId == opId);

        if (op is null)
        {
            return Error.NotFound(description: "Motorcycle not found.");
        }

        return new OpModel(op);
    }

    public async Task<ErrorOr<PaginationModel<OpModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var ops = await dbContext.Operators.AsNoTracking()
                                                     .Skip(page * ROW_COUNT)
                                                     .Take(ROW_COUNT)
                                                     .Select(x => new OpModel(x))
                                                     .ToListAsync();

        var paginationModel = new PaginationModel<OpModel>
        {
            Items = ops,
            Count = await dbContext.Operators.CountAsync()
        };

        return paginationModel;
    }
}
