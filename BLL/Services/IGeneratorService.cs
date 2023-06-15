namespace BLL.Services;

public interface IGeneratorService<TModel>
{
    Task<TModel[]?> GenerateAndSave();
    Task<TModel[]?> LoadToDatabase();
}