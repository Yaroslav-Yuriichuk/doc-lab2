namespace BLL.Services;

public interface IGeneralService<TModel, in TId>
{
    Task<TModel[]?> GetAllAsync();
    Task<TModel?> GetByIdAsync(TId id);

    Task<TModel?> CreateAsync(TModel model);
    Task<TModel?> UpdateAsync(TModel model);
    Task<TModel?> DeleteAsync(TId id);
}