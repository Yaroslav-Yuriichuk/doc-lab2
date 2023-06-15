using DLL.Db;
using DLL.Models;
using DLL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories.Implementations;

public sealed class InboxDbRepository : IInboxRepository
{
    private readonly ApplicationDb _applicationDb;

    public InboxDbRepository(ApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }

    public async Task<Inbox[]?> GetAllAsync() => await _applicationDb.Inboxes.ToArrayAsync();

    public async Task<Inbox?> GetByIdAsync(int id)
    {
        return await _applicationDb.Inboxes.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Inbox?> CreateAsync(Inbox model)
    {
        Inbox? dbInbox = await _applicationDb.Inboxes.FirstOrDefaultAsync(m => m.Id == model.Id);

        if (dbInbox is not null)
        {
            return null;
        }

        _applicationDb.Inboxes.Add(model);
        await _applicationDb.SaveChangesAsync();
        
        return model;
    }

    public async Task<Inbox?> UpdateAsync(Inbox model)
    {
        Inbox? dbInbox = await _applicationDb.Inboxes.FindAsync(model.Id);

        if (dbInbox is null)
        {
            return null;
        }

        dbInbox.Name = model.Name;
        await _applicationDb.SaveChangesAsync();

        return dbInbox;
    }

    public async Task<Inbox?> DeleteAsync(int id)
    {
        Inbox? dbInbox = await _applicationDb.Inboxes.FindAsync(id);

        if (dbInbox is null)
        {
            return null;
        }

        _applicationDb.Inboxes.Remove(dbInbox);
        await _applicationDb.SaveChangesAsync();

        return dbInbox;
    }
}