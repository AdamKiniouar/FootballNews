using FootballNews.Application.Interfaces;
using FootballNews.Domain.IRepositories;
using FootballNews.Infrastructure.Persistence;
using FootballNews.Infrastructure.Repositories;
using FootballNews.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FootballNews.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FootballNewsDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();

        // Register service implementations
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ITeamService, TeamService>();
        services.AddTransient<IArticleService, ArticleService>();

        return services;
    }
}