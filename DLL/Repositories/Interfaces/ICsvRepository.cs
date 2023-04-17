namespace DLL.Repositories.Interfaces;

public interface ICsvRepository<TModel>
{
    Task<TModel[]?> GenerateAndSaveToCsvFile();
    Task<TModel[]?> LoadFromCsvFileToDatabase();
}