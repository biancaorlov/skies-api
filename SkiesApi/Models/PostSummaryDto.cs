namespace SkiesApi.Models;

public class PostSummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string? Excerpt { get; set; }
    public string? Author { get; set; }
    public DateTime PublishedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public int? SubjectId { get; set; }
    public int? DepartmentId { get; set; }
    public int? LocationId { get; set; }
    public int? TypeId { get; set; }
}