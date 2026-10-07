using HackerNews.Application;
using HackerNews.Infrastructure;
using HackerNews.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();
BestStoriesEndpoints.MapEndpoints(app);

app.MapGet("/",()=>Results.Ok("bueenas"));
app.Run();
