using HackerNews.Domain;


namespace HackerNews.Application.Abstractions;

public interface IBestStoriesProvider
{
    Task<List<Story>> GetBestStoriesAsync (int n);  

}