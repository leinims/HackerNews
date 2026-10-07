
using HackerNews.Application.Abstractions;
using HackerNews.Application.DTOs;

namespace HackerNews.Application.Services;

public class BestStoriesServices(IBestStoriesProvider bestStoriesProvider) : IBestStoriesService
{
    public async Task<List<StoryDto>> GetBestStoriesAsync(int n)
    {
        var stories = await bestStoriesProvider.GetBestStoriesAsync(n);
        
        return stories.Select(story => new StoryDto
        {
            Title = story.Title,
            Uri = story.Uri,
            PostedBy = story.PostedBy,
            Time = story.Time,
            Score = story.Score,
            CommentCount = story.CommentCount
        }).ToList();
    }
}