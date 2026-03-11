using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Solution.Database;
using Solution.Database.Entities;

namespace Solution.Services;

public class HeroService : IHeroService
{
    private readonly AppDbContext _dbContext;

    public HeroService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<HeroEntity>> CreateAsync(HeroEntity entity)
    {
        await _dbContext.Heroes.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int id)
    {
        var existing = await _dbContext.Heroes.FindAsync(id);
        if (existing is null)
        {
            throw new KeyNotFoundException($"Hero with id {id} not found.");
        }

        _dbContext.Heroes.Remove(existing);
        await _dbContext.SaveChangesAsync();
        return new Success();
    }

    public async Task<ErrorOr<List<HeroEntity>>> GetAllAsync()
    {
        var list = await _dbContext.Heroes.ToListAsync();
        return list;
    }

    public async Task<ErrorOr<HeroEntity>> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Heroes.FindAsync(id);
        if (entity is null)
        {
            throw new KeyNotFoundException($"Hero with id {id} not found.");
        }

        return entity;
    }

    public async Task<ErrorOr<Success>> UpdateAsync(HeroEntity entity)
    {
        var existing = await _dbContext.Heroes.FindAsync(entity.Id);
        if (existing is null)
        {
            throw new KeyNotFoundException($"Hero with id {entity.Id} not found.");
        }

        existing.Name = entity.Name;
        existing.Intelligence = entity.Intelligence;
        existing.Agility = entity.Agility;
        existing.Strength = entity.Strength;
        existing.Health = entity.Health;
        existing.Physical = entity.Physical;
        existing.Magic = entity.Magic;
        existing.Armor = entity.Armor;
        existing.MagicDef = entity.MagicDef;
        existing.MagicPen = entity.MagicPen;
        existing.ArmorPen = entity.ArmorPen;
        existing.Role = entity.Role;

        _dbContext.Heroes.Update(existing);
        await _dbContext.SaveChangesAsync();
        return new Success();
    }

}
