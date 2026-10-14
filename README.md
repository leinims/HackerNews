# Hacker News Best Stories API

A Rest API that returns the top n Hacker News stories ordered by score (desc). It was built in .NET 10

## What it does

- The API uses a endpoint that bring the list of best stories Ids from Hacker Rank API.
- Gets details for each story.
- Sorts by score (highest first)
- Returns the stories as a JSON


## Architecture ##

- Clean Architecture (It's not the best option for small projects but necessary for the assessment)
- Minimal Api Endpoints
- Dependecy Injection
- Caching for performance.
- Pagination



## Running the API ##

- `https://github.com/leinims/HackerNews.git`
- `cd HackerNews`
- `dotnet run --project src/HackerNews.Api`

## Using the API ##

- GET ` /api/beststories?n={A number between 1 and 500}`

## Pendings ##

- Automated tests
- Structured logging 
- Background cache
- Documentation — this README covers the basics
- Swagger docs.
- Configurable settings.


