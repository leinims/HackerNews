using System.Net.Http.Json;
using HackerNews.Application.Abstractions;
using HackerNews.Domain;
using HackerNews.Infrastructure.Services.Models;

namespace HackerNews.Infrastructure.Services;

public class HackerNewsClient(HttpClient http) : IBestStoriesProvider
{
    public async Task<List<Story>> GetBestStoriesAsync(CancellationToken ct)
    {
        var idList = await http.GetFromJsonAsync<List<int>>($"beststories.json") ?? [];
        
        var stories = new List<Story>();

        foreach (var id in idList)
        {
            var response = await http.GetFromJsonAsync<HackerNewsResponse>($"item/{id}.json");
        
            if(response is null) continue;

            stories.Add(new Story(){
                Id = response.Id,
                Title = response.Title,
                Uri = response.Url,
                PostedBy = response.By,
                Time = DateTimeOffset.FromUnixTimeSeconds(response.Time).DateTime,
                Score = response.Score,
                CommentCount = response.Descendants
                }
            );
        }
        return stories;

    }
}