using FootballNews.Domain.Entities;

namespace FootballNews.Domain.IRepositories;

public interface ITeamRepository
{
    Task<Team> GetByIdAsync(int id);
    Task<IEnumerable<Team>> GetAllAsync();
    Task AddAsync(Team team);
    Task UpdateAsync(Team team);
    Task DeleteAsync(int id);
}