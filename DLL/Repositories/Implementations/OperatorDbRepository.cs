using DLL.Db;
using DLL.Models;
using DLL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repositories.Implementations;

public sealed class OperatorDbRepository : IOperatorRepository
{
    private readonly ApplicationDb _applicationDb;

    public OperatorDbRepository(ApplicationDb applicationDb)
    {
        _applicationDb = applicationDb;
    }

    public async Task<Operator[]?> GetAllAsync() => await _applicationDb.Operators.ToArrayAsync();

    public async Task<Operator?> GetByIdAsync(int id)
    {
        return await _applicationDb.Operators.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Operator?> CreateAsync(Operator model)
    {
        Operator? dbOperator = await _applicationDb.Operators.FirstOrDefaultAsync(m => m.Id == model.Id);

        if (dbOperator is not null)
        {
            return null;
        }

        _applicationDb.Operators.Add(model);
        await _applicationDb.SaveChangesAsync();

        return model;
    }

    public async Task<Operator?> UpdateAsync(Operator model)
    {
        Operator? dbOperator = await _applicationDb.Operators.FindAsync(model.Id);

        if (dbOperator is null)
        {
            return null;
        }

        dbOperator.Name = model.Name;
        await _applicationDb.SaveChangesAsync();

        return dbOperator;
    }

    public async Task<Operator?> DeleteAsync(int id)
    {
        Operator? dbOperator = await _applicationDb.Operators.FindAsync(id);

        if (dbOperator is null)
        {
            return null;
        }

        _applicationDb.Operators.Remove(dbOperator);
        await _applicationDb.SaveChangesAsync();

        return dbOperator;
    }
}