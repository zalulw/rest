using Solution.Database.Entities;

namespace Solution.Services;

public class TypeService(AppDbContext dbContext) : ITypeService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<TypeModel>> CreateAsync(TypeModel model)
    {
        bool exists = await dbContext.Types.AnyAsync(x => x.Name == model.Name);

        if (exists)
        {
            return Error.Conflict(description: "Type already exists!");
        }

        var type = new MotorcycleTypeEntity
        {
            Name = model.Name
        };

        await dbContext.Types.AddAsync(type);
        await dbContext.SaveChangesAsync();

        return new TypeModel(type);
    }

    public async Task<ErrorOr<Success>> UpdateAsync(TypeModel model)
    {
        var entity = await dbContext.Types.FindAsync(model.Id);
        if (entity is null)
        {
            return Error.NotFound();
        }

        entity.Name = model.Name;
        dbContext.Types.Update(entity);
        await dbContext.SaveChangesAsync();

        return Result.Success;
    }

    public async Task<ErrorOr<Success>> DeleteAsync(string typeId)
    {
        if (!int.TryParse(typeId, out var id))
        {
            return Error.NotFound(description: "Invalid type ID.");
        }

        var entity = await dbContext.Types.FindAsync(id);
        if (entity is null)
        {
            return Error.NotFound();
        }

        dbContext.Types.Remove(entity);
        await dbContext.SaveChangesAsync();

        return Result.Success;
    }

    public async Task<ErrorOr<TypeModel>> GetByIdAsync(string typeId)
    {
        if (!int.TryParse(typeId, out var id))
        {
            return Error.NotFound(description: "Invalid type ID.");
        }

        var entity = await dbContext.Types.FindAsync(id);
        if (entity is null)
        {
            return Error.NotFound(description: "Type not found.");
        }

        return new TypeModel(entity);
    }

    public async Task<ErrorOr<List<TypeModel>>> GetAllAsync()
    {
        var types = await dbContext.Types.AsNoTracking()
                                         .OrderBy(t => t.Name)
                                         .Select(t => new TypeModel(t))
                                         .ToListAsync();

        return types;
    }

    public async Task<ErrorOr<PaginationModel<TypeModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var types = await dbContext.Types.AsNoTracking()
                                         .OrderBy(t => t.Name)
                                         .Skip(page * ROW_COUNT)
                                         .Take(ROW_COUNT)
                                         .Select(x => new TypeModel(x))
                                         .ToListAsync();

        var paginationModel = new PaginationModel<TypeModel>
        {
            Items = types,
            Count = await dbContext.Types.CountAsync()
        };

        return paginationModel;
    }
}