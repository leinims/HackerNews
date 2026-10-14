using HackerNews.Application.Abstractions;
using HackerNews.Domain;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace HackerNews.Infrastructure.Services;

public class HackerNewsCache (IMemoryCache _cache, HackerNewsClient _client, ILogger<HackerNewsCache> _logger) : IBestStoriesProvider
{
    private const string CACHE_KEY = "best-stories";
    public static readonly TimeSpan _ttl = TimeSpan.FromMinutes(5);
    private readonly SemaphoreSlim _refreshLock = new(1, 1);


    public async Task<List<Story>> GetBestStoriesAsync(CancellationToken ct)
    {
        if ( _cache.TryGetValue(CACHE_KEY, out List<Story>? cached)
            && cached is not null)
        {
            _logger.LogInformation("Cache found");
            return cached;    
        }
        
        _logger.LogInformation("Cache not found");
        await _refreshLock.WaitAsync(ct);

        try
        {
            if(_cache.TryGetValue(CACHE_KEY, out cached) && cached is not null)
            {
                _logger.LogInformation("Cache found after double check");
                return cached;
            }

            var stories = await _client.GetBestStoriesAsync(ct);

            _cache.Set(CACHE_KEY, stories, _ttl);


            _logger.LogInformation("Cache loaded");
            return stories;
        }
        finally
        {
            _refreshLock.Release();
        }

    }
}