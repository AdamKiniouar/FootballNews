using FootballNews.Application.DTOs;
using FootballNews.Application.Interfaces;
using FootballNews.Domain.Entities;
using FootballNews.Domain.IRepositories;

namespace FootballNews.Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamDto> GetTeamByIdAsync(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            return new TeamDto(team.Name, team.League);
        }

        public async Task<IEnumerable<TeamDto>> GetAllTeamsAsync()
        {
            var teams = await _teamRepository.GetAllAsync();
            var teamDtos = new List<TeamDto>();

            foreach (var team in teams)
            {
                teamDtos.Add(new TeamDto(team.Name, team.League)
                {
                    Id = team.Id,
                });
            }

            return teamDtos;
        }

        public async Task AddTeamAsync(TeamDto teamDto)
        {
            var team = new Team(teamDto.Name, teamDto.League);

            await _teamRepository.AddAsync(team);
        }
    }
}
