using HackerNews.Application.Abstractions;
using HackerNews.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNews.Infrastructure.Services;

public class HackerNewsCache (IMemoryCache cache, HackerNewsClient client) : IBestStoriesProvider
{
    private const string CacheKey = "best-stories";
    public static readonly TimeSpan _ttl = TimeSpan.FromMinutes(5);
    private readonly SemaphoreSlim _refreshLock = new(1, 1);

    public async Task<List<Story>> GetBestStoriesAsync(CancellationToken ct)
    {
        if ( cache.TryGetValue(CacheKey, out List<Story>? cached)
            && cached is not null)
        {
            return cached;    
        }
        await _refreshLock.WaitAsync(ct);

        try
        {
            if(cache.TryGetValue(CacheKey, out cached) && cached is not null)
            {
                return cached;
            }

            var stories = await client.GetBestStoriesAsync(ct);

            cache.Set(CacheKey, stories, _ttl);

            return stories;
        }
        finally
        {
            _refreshLock.Release();
        }

    }
}