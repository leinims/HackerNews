# Hacker News Best Stories API

A RestFull API built with ASP.NET that returns the top n Hacker News stories ordered by score (descending) from Hacker News API (Check documentation in https://github.com/HackerNews/API). 

## What it does

- The API uses a endpoint that bring the list of best stories Ids from Hacker Rank API.
- Gets details for each story.
- Sorts by score (highest first)
- Returns the stories as a JSON


## Features ##

- .NET 10(Asp.NET Core)
- Serilog
- IMemoryCache
- CancellationToken
- SemaphoreSlim


## Running the API ##

- Clone project: `https://github.com/leinims/HackerNews.git`
- Then `cd HackerNews`
- Run using `dotnet run --project src/HackerNews.Api`

## Using the API ##

- Swagger `/swagger`
- GET ` /api/beststories?n={A number between 1 and 500}`

## Architecture ##

- Clean Architecture
    - HackerNews.Api -> API Layer using Minimal API
    - HackerNews.Application -> Application Layer using Dependecy inversion on Provider
    - HackerNews.Domain -> Domain Layer
    - HackerNews.Infrastructure -> Infractruture Layer allows enable/disable Cache changing DI   

## Assumptions ##

- Get Best stories from all records. Not just from n records get
- Failed responses are ignored (get empty entities)


## Pendings ##

- Distribuited Cache and Background warm up 
- Polly
- Detailed Documentation — this README covers the basics
- Pagination
- Telemetry
- Integration Tests


