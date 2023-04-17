using BLL.Services.Interfaces;
using DLL.Models;
using DLL.Repositories.Interfaces;

namespace BLL.Services.Implementations;

public sealed class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;

    public MessageService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<Message[]?> GetAllAsync() => await _messageRepository.GetAllAsync();
    public async Task<Message?> GetByIdAsync(int id) => await _messageRepository.GetByIdAsync(id);

    public async Task<Message?> CreateAsync(Message message) => await _messageRepository.CreateAsync(message);
    public async Task<Message?> UpdateAsync(Message message) => await _messageRepository.UpdateAsync(message);
    public async Task<Message?> DeleteAsync(int id) => await _messageRepository.DeleteAsync(id);

    public async Task<Message[]?> GenerateAndSave() => await _messageRepository.GenerateAndSaveToCsvFile();
    public async Task<Message[]?> LoadToDatabase() => await _messageRepository.LoadFromCsvFileToDatabase();
}