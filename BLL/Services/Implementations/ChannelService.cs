using BLL.Services.Interfaces;
using DLL.Models;
using DLL.Repositories.Interfaces;

namespace BLL.Services.Implementations;

public sealed class ChannelService : IChannelService
{
    private readonly IChannelRepository _channelRepository;

    public ChannelService(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    public async Task<Channel[]?> GetAllAsync() => await _channelRepository.GetAllAsync();
    public async Task<Channel?> GetByIdAsync(int id) => await _channelRepository.GetByIdAsync(id);

    public async Task<Channel?> CreateAsync(Channel channel) => await _channelRepository.CreateAsync(channel);
    public async Task<Channel?> UpdateAsync(Channel channel) => await _channelRepository.UpdateAsync(channel);
    public async Task<Channel?> DeleteAsync(int id) => await _channelRepository.DeleteAsync(id);
}