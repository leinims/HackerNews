using HackerNews.Application.Services;

namespace HackerNews.Api.Endpoints;


public static class BestStoriesEndpoints
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/beststories", 
            async (int n, IBestStoriesService service, CancellationToken ct) =>
            {
                if(n > 500 || n < 1)
                    return Results.BadRequest("n Range must be between 1 and 2");
                
                var stories = await service.GetBestStoriesAsync(n, ct);
                
                return Results.Ok(stories);

            }
        );

        return app; 
    }
}