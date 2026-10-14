using System.Net.Http.Json;
using HackerNews.Application.Abstractions;
using HackerNews.Domain;
using HackerNews.Infrastructure.Services.Models;
using Microsoft.Extensions.Logging;

namespace HackerNews.Infrastructure.Services;

public class HackerNewsClient(HttpClient _http, ILogger<HackerNewsClient> _logger) : IBestStoriesProvider
{
    public async Task<List<Story>> GetBestStoriesAsync(CancellationToken ct)
    {
        var stories = new List<Story>();

        try
        {
          _logger.LogInformation("Getting Info from beststories.json");
          var idList = await _http.GetFromJsonAsync<List<int>>($"beststories.json") ?? [];
          
          _logger.LogInformation("Getting Info (List) from each item");
            foreach (var id in idList)
            {
                var response = await _http.GetFromJsonAsync<HackerNewsResponse>($"item/{id}.json");
            
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
        }
        catch (Exception exception)
        {
            _logger.LogWarning(exception, "Error fetching Info");
        }
        finally
        {
            _logger.LogInformation("Resquest has finished");
        }
        
        return stories;

    }
}