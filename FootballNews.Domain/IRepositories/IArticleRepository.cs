using FootballNews.Domain.Entities;

namespace FootballNews.Domain.IRepositories;

public interface IArticleRepository
{
    Task<Article> GetByIdAsync(int id);
    Task<IEnumerable<Article>> GetAllAsync();
    Task AddAsync(Article article);
    Task UpdateAsync(Article article);
    Task DeleteAsync(int id);
    Task PublishAsync(int id, bool isPublished);

}