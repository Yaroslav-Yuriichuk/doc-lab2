namespace DLL.Repositories;

public interface ICsvRepository<TModel>
{
    Task<TModel[]?> GenerateAndSaveToCsvFile();
    Task<TModel[]?> LoadFromCsvFileToDatabase();
}