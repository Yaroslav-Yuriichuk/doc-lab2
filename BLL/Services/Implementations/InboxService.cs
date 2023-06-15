using BLL.Services.Interfaces;
using DLL.Models;
using DLL.Repositories.Interfaces;

namespace BLL.Services.Implementations;

public sealed class InboxService : IInboxService
{
    private readonly IInboxRepository _inboxRepository;

    public InboxService(IInboxRepository inboxRepository)
    {
        _inboxRepository = inboxRepository;
    }

    public async Task<Inbox[]?> GetAllAsync() => await _inboxRepository.GetAllAsync();
    public async Task<Inbox?> GetByIdAsync(int id) => await _inboxRepository.GetByIdAsync(id);

    public async Task<Inbox?> CreateAsync(Inbox inbox) => await _inboxRepository.CreateAsync(inbox);
    public async Task<Inbox?> UpdateAsync(Inbox inbox) => await _inboxRepository.UpdateAsync(inbox);
    public async Task<Inbox?> DeleteAsync(int id) => await _inboxRepository.DeleteAsync(id);
}