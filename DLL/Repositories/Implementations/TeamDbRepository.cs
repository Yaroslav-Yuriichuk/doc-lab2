using DLL.Db;
using DLL.Models;
using DLL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories.Implementations;

public sealed class TeamDbRepository : ITeamRepository
{
    private readonly ApplicationDb _applicationDb;

    public TeamDbRepository(ApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }

    public async Task<Team[]?> GetAllAsync() => await _applicationDb.Teams.ToArrayAsync();

    public async Task<Team?> GetByIdAsync(int id)
    {
        return await _applicationDb.Teams.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Team?> CreateAsync(Team model)
    {
        Team? dbTeam = await _applicationDb.Teams.FirstOrDefaultAsync(m => m.Id == model.Id);

        if (dbTeam is not null)
        {
            return null;
        }

        _applicationDb.Teams.Add(model);
        await _applicationDb.SaveChangesAsync();
        
        return model;
    }

    public async Task<Team?> UpdateAsync(Team model)
    {
        Team? dbTeam = await _applicationDb.Teams.FindAsync(model.Id);

        if (dbTeam is null)
        {
            return null;
        }

        dbTeam.Name = model.Name;
        await _applicationDb.SaveChangesAsync();

        return dbTeam;
    }

    public async Task<Team?> DeleteAsync(int id)
    {
        Team? dbTeam = await _applicationDb.Teams.FindAsync(id);

        if (dbTeam is null)
        {
            return null;
        }

        _applicationDb.Teams.Remove(dbTeam);
        await _applicationDb.SaveChangesAsync();

        return dbTeam;
    }
}