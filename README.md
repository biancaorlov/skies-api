# Skies API (Mock)
This is a .NET 8 ASP.NET Core Web API prototype for Skies app.
The API is currently using mock services (no real SKIES integration yet) and is intended to support early development and testing of the app.

## Requirements
- .NET 8 SDK

## Run locally
```bash
cd SkiesApi
dotnet restore
dotnet run
```

## Swagger (API documentation)
When the API is running, open Swagger in your browser:
http://localhost:5124/swagger
## Available endpoints
### User
- GET /api/users/{username}
### Posts
- GET /api/posts
- GET /api/posts/{id}
### Activities
- GET /api/activities
- GET /api/activities/{id}

## Notes
- All data is mocked
- No authentication is implemented yet
- This API is a prototype and will be extended later
