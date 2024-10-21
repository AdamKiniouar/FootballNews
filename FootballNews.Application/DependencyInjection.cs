using FootballNews.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FootballNews.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register other application-specific services

        return services;
    }
}