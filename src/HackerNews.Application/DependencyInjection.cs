
using HackerNews.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HackerNews.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication( this IServiceCollection services)
    {
        services.AddScoped<IBestStoriesService, BestStoriesServices>();
        return services;        
    }
}