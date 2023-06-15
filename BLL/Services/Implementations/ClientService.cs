using BLL.Services.Interfaces;
using DLL.Models;
using DLL.Repositories.Interfaces;

namespace BLL.Services.Implementations;

public sealed class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Client[]?> GetAllAsync() => await _clientRepository.GetAllAsync();
    public async Task<Client?> GetByIdAsync(int id) => await _clientRepository.GetByIdAsync(id);

    public async Task<Client?> CreateAsync(Client client) => await _clientRepository.CreateAsync(client);
    public async Task<Client?> UpdateAsync(Client client) => await _clientRepository.UpdateAsync(client);
    public async Task<Client?> DeleteAsync(int id) => await _clientRepository.DeleteAsync(id);
}