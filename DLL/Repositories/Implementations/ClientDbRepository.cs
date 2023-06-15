using DLL.Db;
using DLL.Models;
using DLL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories.Implementations;

public sealed class ClientDbRepository : IClientRepository
{
    private readonly ApplicationDb _applicationDb;

    public ClientDbRepository(ApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }

    public async Task<Client[]?> GetAllAsync() => await _applicationDb.Clients.ToArrayAsync();

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _applicationDb.Clients.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Client?> CreateAsync(Client model)
    {
        Client? dbClient = await _applicationDb.Clients.FirstOrDefaultAsync(m => m.Id == model.Id);

        if (dbClient is not null)
        {
            return null;
        }

        _applicationDb.Clients.Add(model);
        await _applicationDb.SaveChangesAsync();
        
        return model;
    }

    public async Task<Client?> UpdateAsync(Client model)
    {
        Client? dbClient = await _applicationDb.Clients.FindAsync(model.Id);

        if (dbClient is null)
        {
            return null;
        }

        dbClient.Name = model.Name;
        await _applicationDb.SaveChangesAsync();

        return dbClient;
    }

    public async Task<Client?> DeleteAsync(int id)
    {
        Client? dbClient = await _applicationDb.Clients.FindAsync(id);

        if (dbClient is null)
        {
            return null;
        }

        _applicationDb.Clients.Remove(dbClient);
        await _applicationDb.SaveChangesAsync();

        return dbClient;
    }
}