using DLL.Db;
using DLL.Models;
using DLL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories.Implementations;

public sealed class ChannelDbRepository : IChannelRepository
{
    private readonly ApplicationDb _applicationDb;

    public ChannelDbRepository(ApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }

    public async Task<Channel[]?> GetAllAsync() => await _applicationDb.Channels.ToArrayAsync();

    public async Task<Channel?> GetByIdAsync(int id)
    {
        return await _applicationDb.Channels.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Channel?> CreateAsync(Channel model)
    {
        Channel? dbChannel = await _applicationDb.Channels.FirstOrDefaultAsync(m => m.Id == model.Id);

        if (dbChannel is not null)
        {
            return null;
        }

        _applicationDb.Channels.Add(model);
        await _applicationDb.SaveChangesAsync();

        return model;
    }

    public async Task<Channel?> UpdateAsync(Channel model)
    {
        Channel? dbChannel = await _applicationDb.Channels.FindAsync(model.Id);

        if (dbChannel is null)
        {
            return null;
        }

        dbChannel.Name = model.Name;
        await _applicationDb.SaveChangesAsync();

        return dbChannel;
    }

    public async Task<Channel?> DeleteAsync(int id)
    {
        Channel? dbChannel = await _applicationDb.Channels.FindAsync(id);

        if (dbChannel is null)
        {
            return null;
        }

        _applicationDb.Channels.Remove(dbChannel);
        await _applicationDb.SaveChangesAsync();

        return dbChannel;
    }
}