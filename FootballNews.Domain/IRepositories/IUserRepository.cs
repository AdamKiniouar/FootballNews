using FootballNews.Domain.Entities;

namespace FootballNews.Domain.IRepositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> GetByUserNameAsync(string userName);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}