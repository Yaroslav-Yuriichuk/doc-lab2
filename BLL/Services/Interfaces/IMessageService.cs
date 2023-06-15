using DLL.Models;

namespace BLL.Services.Interfaces;

public interface IMessageService : IGeneralService<Message, int>, IGeneratorService<Message> { }