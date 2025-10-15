using Core.Models;

namespace Core.Interfaces;

public interface IOpService
{ 
    Task<ErrorOr<<OpModel>> CreateAsync(OpModel model);
    Task<ErrorOr<<Success>> UpdateAsync(OpModel model);
    Task<ErrorOr<<Success>> DeleteAsync(string opId);
    Task<ErrorOr<<OpModel>> GetByIdAsync(string opId);
    Task<ErrorOr<List<<OpModel>>> GetAllAsync();
    Task<ErrorOr<<PaginationModel>> CreateAsync(OpModel model);

}
