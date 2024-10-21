using FootballNews.Domain.Entities;
using FootballNews.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using FootballNews.Domain.IRepositories;

namespace FootballNews.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly FootballNewsDbContext _context;

    public TeamRepository(FootballNewsDbContext context)
    {
        _context = context;
    }

    public async Task<Team> GetByIdAsync(int id)
    {
        return await _context.Teams.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams.ToListAsync();
    }

    public async Task AddAsync(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Team team)
    {
        _context.Teams.Update(team);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team != null)
        {
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
        }
    }
}