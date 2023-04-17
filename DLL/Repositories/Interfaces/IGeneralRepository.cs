using DLL.Models;

namespace DLL.Repositories.Interfaces;

public interface IGeneralRepository<TModel, in TId>
{
    Task<TModel[]?> GetAllAsync();
    Task<TModel?> GetByIdAsync(TId id);

    Task<Message?> CreateAsync(TModel model);
    Task<TModel?> UpdateAsync(TModel model);
    Task<TModel?> DeleteAsync(TId id);
}