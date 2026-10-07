using HackerNews.Application.DTOs;

namespace HackerNews.Application.Services;

public interface IBestStoriesService
{
    Task<List<StoryDto>> GetBestStoriesAsync(int n, CancellationToken ct);
}