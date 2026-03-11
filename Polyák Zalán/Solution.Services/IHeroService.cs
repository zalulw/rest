using ErrorOr;
using Solution.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Services;

public interface IHeroService
{
    Task<ErrorOr<HeroEntity>> CreateAsync(HeroEntity entity);
    Task<ErrorOr<Success>> UpdateAsync(HeroEntity entity);
    Task<ErrorOr<Success>> DeleteAsync(int id);
    Task<ErrorOr<List<HeroEntity>>> GetAllAsync();
    Task<ErrorOr<HeroEntity>> GetByIdAsync(int id);
}
