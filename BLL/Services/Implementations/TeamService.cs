using BLL.Services.Interfaces;
using DLL.Models;
using DLL.Repositories.Interfaces;

namespace BLL.Services.Implementations;

public sealed class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<Team[]?> GetAllAsync() => await _teamRepository.GetAllAsync();
    public async Task<Team?> GetByIdAsync(int id) => await _teamRepository.GetByIdAsync(id);

    public async Task<Team?> CreateAsync(Team team) => await _teamRepository.CreateAsync(team);
    public async Task<Team?> UpdateAsync(Team team) => await _teamRepository.UpdateAsync(team);
    public async Task<Team?> DeleteAsync(int id) => await _teamRepository.DeleteAsync(id);
}