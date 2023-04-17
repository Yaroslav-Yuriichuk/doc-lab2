using System.Globalization;
using CsvHelper;
using DLL.Csv.Interfaces;

namespace DLL.Csv.Implementations;

public class DefaultCsvFileService<TModel> : ICsvFileService<TModel>
{
    public async Task<TModel[]?> ReadAsync(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        using var streamReader = new StreamReader(path);
        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

        IAsyncEnumerable<TModel> csvModels = csvReader.GetRecordsAsync<TModel>();

        if (csvModels == null)
        {
            return null;
        }

        List<TModel> models = new List<TModel>();

        await foreach (var model in csvModels)
        {
            models.Add(model);
        }

        return models.ToArray();
    }

    public async Task WriteAsync(string path, TModel[]? models)
    {
        if (models == null)
        {
            return;
        }

        await using var streamWriter = new StreamWriter(path);
        await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        await csvWriter.WriteRecordsAsync(models);
    }
}