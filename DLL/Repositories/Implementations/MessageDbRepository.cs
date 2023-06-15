using DLL.Csv.Interfaces;
using DLL.Db;
using DLL.Models;
using DLL.Repositories.Interfaces;
using DLL.Utils;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories.Implementations;

public sealed class MessageDbRepository : IMessageRepository
{
    private const string CsvFileName = "Messages.csv";

    private readonly ApplicationDb _applicationDb;
    private readonly ICsvFileService<Message> _csvFileService;

    private readonly string _csvFilePath = Path.Combine(Environment.CurrentDirectory, CsvFileName);

    public MessageDbRepository(ApplicationDb applicationDb, ICsvFileService<Message> csvFileService)
    {
        _applicationDb = applicationDb;
        _csvFileService = csvFileService;
    }

    public async Task<Message[]?> GetAllAsync() => await _applicationDb.Messages.ToArrayAsync();

    public async Task<Message?> GetByIdAsync(int id)
    {
        return await _applicationDb.Messages.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Message?> CreateAsync(Message model)
    {
        Message? dbMessage = await _applicationDb.Messages.FirstOrDefaultAsync(m => m.Id == model.Id);

        if (dbMessage is not null)
        {
            return null;
        }

        _applicationDb.Messages.Add(model);
        await _applicationDb.SaveChangesAsync();

        return model;
    }

    public async Task<Message?> UpdateAsync(Message model)
    {
        Message? dbMessage = await _applicationDb.Messages.FindAsync(model.Id);

        if (dbMessage is null)
        {
            return null;
        }

        dbMessage.Text = model.Text;
        await _applicationDb.SaveChangesAsync();

        return dbMessage;
    }

    public async Task<Message?> DeleteAsync(int id)
    {
        Message? dbMessage = await _applicationDb.Messages.FindAsync(id);

        if (dbMessage is null)
        {
            return null;
        }

        _applicationDb.Messages.Remove(dbMessage);
        await _applicationDb.SaveChangesAsync();

        return dbMessage;
    }

    public async Task<Message[]?> GenerateAndSaveToCsvFile()
    {
        const int recordsCount = 1000;

        Message[] messages = Enumerable
            .Range(0, recordsCount)
            .Select(_ => new Message
            {
                Text = StringUtil.RandomString(47),
            })
            .ToArray();

        await _csvFileService.WriteAsync(_csvFilePath, messages);

        return messages;
    }

    public async Task<Message[]?> LoadFromCsvFileToDatabase()
    {
        Message[]? messages = await _csvFileService.ReadAsync(_csvFilePath);

        if (messages is null)
        {
            return Array.Empty<Message>();
        }

        await _applicationDb.Messages.AddRangeAsync(messages);
        await _applicationDb.SaveChangesAsync();

        return messages;
    }
}