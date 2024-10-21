using FootballNews.Application.DTOs;

namespace FootballNews.Application.Interfaces;

public interface ITeamService
{
    Task<TeamDto> GetTeamByIdAsync(int id);
    Task<IEnumerable<TeamDto>> GetAllTeamsAsync();
    Task AddTeamAsync(TeamDto teamDto);
}