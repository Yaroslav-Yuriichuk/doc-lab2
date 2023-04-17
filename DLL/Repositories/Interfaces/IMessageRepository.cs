using DLL.Models;

namespace DLL.Repositories.Interfaces;

public interface IMessageRepository : IGeneralRepository<Message, int>, ICsvRepository<Message>{ }