namespace DLL.Csv.Interfaces;

public interface ICsvFileService<TModel>
{
    Task<TModel[]?> ReadAsync(string path);
    Task WriteAsync(string path, TModel[]? models);
}