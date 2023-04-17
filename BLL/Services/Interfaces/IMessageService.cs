using DLL.Models;

namespace BLL.Services.Interfaces;

public interface IMessageService : IGeneratorService<Message>
{
    Task<Message[]?> GetAllAsync();
    Task<Message?> GetByIdAsync(int id);

    Task<Message?> CreateAsync(Message message);
    Task<Message?> UpdateAsync(Message message);
    Task<Message?> DeleteAsync(int id);
}