using FootballNews.Domain.Entities;
using FootballNews.Domain.IRepositories;
using FootballNews.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace FootballNews.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FootballNewsDbContext _context;

    public UserRepository(FootballNewsDbContext context)
    {
        _context = context;
    }
    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<User> GetByUserNameAsync(string userName)
    {
        return await _context.Users.FindAsync(userName) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        user.PasswordHash = HashPassword(user.PasswordHash);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        user.PasswordHash = HashPassword(user.PasswordHash);
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}