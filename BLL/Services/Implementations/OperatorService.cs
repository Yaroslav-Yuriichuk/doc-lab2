using BLL.Services.Interfaces;
using DLL.Models;
using DLL.Repositories.Interfaces;

namespace BLL.Services.Implementations;

public sealed class OperatorService : IOperatorService
{
    private readonly IOperatorRepository _operatorRepository;

    public OperatorService(IOperatorRepository operatorRepository)
    {
        _operatorRepository = operatorRepository;
    }

    public async Task<Operator[]?> GetAllAsync() => await _operatorRepository.GetAllAsync();
    public async Task<Operator?> GetByIdAsync(int id) => await _operatorRepository.GetByIdAsync(id);

    public async Task<Operator?> CreateAsync(Operator operatorModel) => await _operatorRepository.CreateAsync(operatorModel);
    public async Task<Operator?> UpdateAsync(Operator operatorModel) => await _operatorRepository.UpdateAsync(operatorModel);
    public async Task<Operator?> DeleteAsync(int id) => await _operatorRepository.DeleteAsync(id);
}