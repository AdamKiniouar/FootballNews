using Microsoft.EntityFrameworkCore;
using FootballNews.Domain.Entities;
using FootballNews.Infrastructure.Configurations;

namespace FootballNews.Infrastructure.Persistence;

public class FootballNewsDbContext : DbContext
{
    public FootballNewsDbContext(DbContextOptions<FootballNewsDbContext> options)
        : base(options)
    { }

    public DbSet<Article> Articles { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());

    }
}