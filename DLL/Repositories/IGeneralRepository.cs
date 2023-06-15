namespace DLL.Repositories;

public interface IGeneralRepository<TModel, in TId>
{
    Task<TModel[]?> GetAllAsync();
    Task<TModel?> GetByIdAsync(TId id);

    Task<TModel?> CreateAsync(TModel model);
    Task<TModel?> UpdateAsync(TModel model);
    Task<TModel?> DeleteAsync(TId id);
}