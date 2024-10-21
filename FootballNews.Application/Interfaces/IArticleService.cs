using FootballNews.Application.DTOs;

namespace FootballNews.Application.Interfaces
{
    public interface IArticleService
    {
        Task<ArticleDto> GetArticleByIdAsync(int id);
        Task<IEnumerable<ArticleDto>> GetAllArticlesAsync();
        Task AddArticleAsync(ArticleDto articleDto);
        Task PublishArticleAsync(PublishArticleDto publishArticleDto);
        Task DeleteArticleAsync(int id);

    }
}

