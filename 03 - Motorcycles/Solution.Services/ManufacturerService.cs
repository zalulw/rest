using Solution.Database.Entities;

namespace Solution.Services;

public class ManufacturerService(AppDbContext dbContext) : IManufacturerService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<ManufacturerModel>> CreateAsync(ManufacturerModel model)
    {
        bool exists = await dbContext.Manufacturers.AnyAsync(x => x.Name == model.Name);

        if (exists)
        {
            return Error.Conflict(description: "Manufacturer already exists!");
        }

        var manufacturer = new ManufacturerEntity
        {
            Name = model.Name
        };

        await dbContext.Manufacturers.AddAsync(manufacturer);
        await dbContext.SaveChangesAsync();

        return new ManufacturerModel(manufacturer);
    }

    public async Task<ErrorOr<Success>> UpdateAsync(ManufacturerModel model)
    {
        var entity = await dbContext.Manufacturers.FindAsync(model.Id);
        if (entity is null)
        {
            return Error.NotFound();
        }

        entity.Name = model.Name;
        dbContext.Manufacturers.Update(entity);
        await dbContext.SaveChangesAsync();

        return Result.Success;
    }

    public async Task<ErrorOr<Success>> DeleteAsync(string manufacturerId)
    {
        if (!int.TryParse(manufacturerId, out var id))
        {
            return Error.NotFound(description: "Invalid manufacturer ID.");
        }

        var entity = await dbContext.Manufacturers.FindAsync(id);
        if (entity is null)
        {
            return Error.NotFound();
        }

        dbContext.Manufacturers.Remove(entity);
        await dbContext.SaveChangesAsync();

        return Result.Success;
    }

    public async Task<ErrorOr<ManufacturerModel>> GetByIdAsync(string manufacturerId)
    {
        if (!int.TryParse(manufacturerId, out var id))
        {
            return Error.NotFound(description: "Invalid manufacturer ID.");
        }

        var entity = await dbContext.Manufacturers.FindAsync(id);
        if (entity is null)
        {
            return Error.NotFound(description: "Manufacturer not found.");
        }

        return new ManufacturerModel(entity);
    }

    public async Task<ErrorOr<List<ManufacturerModel>>> GetAllAsync()
    {
        var manufacturers = await dbContext.Manufacturers.AsNoTracking()
                                         .OrderBy(m => m.Name)
                                         .Select(m => new ManufacturerModel(m))
                                         .ToListAsync();

        return manufacturers;
    }

    public async Task<ErrorOr<PaginationModel<ManufacturerModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var manufacturers = await dbContext.Manufacturers.AsNoTracking()
                                         .OrderBy(m => m.Name)
                                         .Skip(page * ROW_COUNT)
                                         .Take(ROW_COUNT)
                                         .Select(m => new ManufacturerModel(m))
                                         .ToListAsync();

        var paginationModel = new PaginationModel<ManufacturerModel>
        {
            Items = manufacturers,
            Count = await dbContext.Manufacturers.CountAsync()
        };

        return paginationModel;
    }
}