using HackerNews.Application.Services;

namespace HackerNews.Api.Endpoints;


public static class BestStoriesEndpoints
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/beststories", async (int n, IBestStoriesService service) =>
        {
            var stories = await service.GetBestStoriesAsync(n);
            
            return Results.Ok(stories);

        });

        return app; 
    }
}