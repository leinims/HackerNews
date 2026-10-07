
using HackerNews.Application.Abstractions;
using HackerNews.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HackerNews.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure (this IServiceCollection services)
    {
        services.AddMemoryCache();

        services.AddHttpClient<HackerNewsClient>( 
            client =>
            {
                client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");
            });

        services.AddScoped<IBestStoriesProvider, HackerNewsCache>();

        return services;   
    }
}