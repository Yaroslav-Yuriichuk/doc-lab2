namespace BLL.Services.Interfaces;

public interface IGeneratorService<TModel>
{
    Task<TModel[]?> GenerateAndSave();
    Task<TModel[]?> LoadToDatabase();
}