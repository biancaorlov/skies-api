using SkiesApi.Models;

namespace SkiesApi.Services;

public class MockPostService : IPostService
{
    private static readonly List<PostDetailDto> _posts = new()
    {
        new PostDetailDto
        {
            Id = 1001,
            Title = "Travel policy update",
            Excerpt = "New travel policy from 2026...",
            Author = "bior",
            PublishedAt = DateTime.UtcNow.AddDays(-10),
            ModifiedAt = DateTime.UtcNow.AddDays(-2),
            SubjectId = 8,      // Activities (exempel från PDF)
            DepartmentId = 74,
            LocationId = 10,
            TypeId = 2,
            ContentHtml = "<p>This is a mock post content.</p>"
        },
        new PostDetailDto
        {
            Id = 1002,
            Title = "Office info",
            Excerpt = "Practical info about the office...",
            Author = "anna",
            PublishedAt = DateTime.UtcNow.AddDays(-20),
            ModifiedAt = null,
            SubjectId = 0,
            DepartmentId = null,
            LocationId = 10,
            TypeId = 0,
            ContentHtml = "<p>Mock content about the office.</p>"
        }
    };

    public Task<PostDetailDto?> GetByIdAsync(int id)
    {
        var found = _posts.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(found);
    }

    public Task<IEnumerable<PostSummaryDto>> SearchAsync(
        string? q,
        int? subjectId,
        int? departmentId,
        int? locationId,
        int? typeId,
        string? sort,
        string? author)
    {
        IEnumerable<PostDetailDto> query = _posts;

        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(p => (p.Title + " " + p.Excerpt).Contains(q, StringComparison.OrdinalIgnoreCase));

        if (subjectId.HasValue)
            query = query.Where(p => p.SubjectId == subjectId);

        if (departmentId.HasValue)
            query = query.Where(p => p.DepartmentId == departmentId);

        if (locationId.HasValue)
            query = query.Where(p => p.LocationId == locationId);

        if (typeId.HasValue)
            query = query.Where(p => p.TypeId == typeId);

        if (!string.IsNullOrWhiteSpace(author))
            query = query.Where(p => string.Equals(p.Author, author, StringComparison.OrdinalIgnoreCase));

        // sort: "date" eller "modifiedDate" (enligt din PDF: datum / edatum) :contentReference[oaicite:2]{index=2}
        query = (sort?.ToLowerInvariant()) switch
        {
            "modifieddate" => query.OrderByDescending(p => p.ModifiedAt ?? p.PublishedAt),
            _ => query.OrderByDescending(p => p.PublishedAt),
        };

        // Returnera summaries
        var result = query.Select(p => new PostSummaryDto
        {
            Id = p.Id,
            Title = p.Title,
            Excerpt = p.Excerpt,
            Author = p.Author,
            PublishedAt = p.PublishedAt,
            ModifiedAt = p.ModifiedAt,
            SubjectId = p.SubjectId,
            DepartmentId = p.DepartmentId,
            LocationId = p.LocationId,
            TypeId = p.TypeId
        });

        return Task.FromResult(result);
    }
}