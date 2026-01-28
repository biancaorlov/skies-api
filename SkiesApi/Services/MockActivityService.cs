using SkiesApi.Models;

namespace SkiesApi.Services;

public class MockActivityService : IActivityService
{
    private const string MyCityMock = "Göteborg";

    private static readonly List<ActivityDetailDto> _activities = new()
    {
        new ActivityDetailDto
        {
            Id = 501,
            Title = "Afterwork",
            City = "Göteborg",
            StartsAt = DateTime.UtcNow.AddDays(7),
            LocationText = "Office",
            Description = "Mock description for afterwork."
        },
        new ActivityDetailDto
        {
            Id = 502,
            Title = "Lunch & Learn",
            City = "Stockholm",
            StartsAt = DateTime.UtcNow.AddDays(14),
            LocationText = "Conference room",
            Description = "Mock description for lunch & learn."
        }
    };

    public Task<ActivityDetailDto?> GetByIdAsync(int id)
    {
        var found = _activities.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(found);
    }

    public Task<IEnumerable<ActivitySummaryDto>> ListAsync(bool? myCity, string? city)
    {
        IEnumerable<ActivityDetailDto> query = _activities;

        // Enligt din observation: "my city" filter är server-side i SKIES :contentReference[oaicite:3]{index=3}
        // Vi simulerar med MyCityMock.
        if (myCity == true)
            query = query.Where(a => a.City == MyCityMock);

        if (!string.IsNullOrWhiteSpace(city))
            query = query.Where(a => string.Equals(a.City, city, StringComparison.OrdinalIgnoreCase));

        var result = query.Select(a => new ActivitySummaryDto
        {
            Id = a.Id,
            Title = a.Title,
            City = a.City,
            StartsAt = a.StartsAt,
            LocationText = a.LocationText
        });

        return Task.FromResult(result);
    }
}