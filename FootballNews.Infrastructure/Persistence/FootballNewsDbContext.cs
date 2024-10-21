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

        // Seed data
        modelBuilder.Entity<User>().HasData(
            new User("Admin", "admin@example.com", "Password1337"));

        modelBuilder.Entity<Team>().HasData(
            new Team("IFK Göteborg", 1)
            {
                Icon = "To Do",
                Description = "To Do",
                Trainer = "To Do"
            }
        );

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());

    }
}