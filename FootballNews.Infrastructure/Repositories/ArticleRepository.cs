using FootballNews.Domain.Entities;
using FootballNews.Infrastructure.Persistence;
using FootballNews.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FootballNews.Infrastructure.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly FootballNewsDbContext _context;

    public ArticleRepository(FootballNewsDbContext context)
    {
        _context = context;
    }

    public async Task<Article> GetByIdAsync(int id)
    {
        return await _context.Articles.FindAsync(id) ?? throw new InvalidOperationException($"Article with ID {id} not found.");
    }


    public async Task<IEnumerable<Article>> GetAllAsync()
    {
        return await _context.Articles.ToListAsync();
    }

    public async Task AddAsync(Article? article)
    {
        await _context.Articles.AddAsync(article);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Article? article)
    {
        _context.Articles.Update(article);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article != null)
        {
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }
    }

    public async Task PublishAsync(int id, bool isPublished)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article == null)
        {
            throw new KeyNotFoundException($"Article with ID {id} not found.");
        }

        article.Published = isPublished;
        _context.Entry(article).Property(a => a.Published).IsModified = true;
        await _context.SaveChangesAsync();
    }
}