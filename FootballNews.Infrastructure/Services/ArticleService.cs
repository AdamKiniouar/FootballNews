using FootballNews.Application.DTOs;
using FootballNews.Application.Interfaces;
using FootballNews.Domain.Entities;
using FootballNews.Domain.IRepositories;
using System;
using System.Reflection.Metadata;

namespace FootballNews.Infrastructure.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ArticleDto> GetArticleByIdAsync(int id)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            return new ArticleDto(
                article.Title,
                article.Content,
                article.Url,
                article.Source,
                article.PublishedDate)
            {
                Id = article.Id,
                TeamId = article.TeamId
            };
        }

        public async Task<IEnumerable<ArticleDto>> GetAllArticlesAsync()
        {
            var articles = await _articleRepository.GetAllAsync();

            return articles.Select(article => new ArticleDto(
                article.Title,
                article.Content,
                article.Url,
                article.Source,
                article.PublishedDate)
            {
                Id = article.Id,
                TeamId = article.TeamId

            }).ToList();
        }

        public async Task AddArticleAsync(ArticleDto articleDto)
        {
            var article = new Article(
                articleDto.Title,
                articleDto.Content,
                articleDto.Url,
                articleDto.Source,
                articleDto.PublishedDate)
            {
                FetchDate = DateTime.UtcNow,
                TeamId = articleDto.TeamId
            };

            await _articleRepository.AddAsync(article);
        }

        public async Task PublishArticleAsync(PublishArticleDto publishArticleDto)
        {
            await _articleRepository.PublishAsync(publishArticleDto.Id, publishArticleDto.IsPublished);
        }

        public async Task DeleteArticleAsync(int id)
        {
            await _articleRepository.DeleteAsync(id);
        }
    }
}
