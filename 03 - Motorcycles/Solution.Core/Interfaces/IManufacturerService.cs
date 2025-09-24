namespace Solution.Core.Interfaces;

public interface IManufacturerService
{
    Task<ErrorOr<ManufacturerModel>> CreateAsync(ManufacturerModel model);
    Task<ErrorOr<Success>> UpdateAsync(ManufacturerModel model);
    Task<ErrorOr<Success>> DeleteAsync(string manufacturerId);
    Task<ErrorOr<ManufacturerModel>> GetByIdAsync(string manufacturerId);
    Task<ErrorOr<List<ManufacturerModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<ManufacturerModel>>> GetPagedAsync(int page = 0);



}
