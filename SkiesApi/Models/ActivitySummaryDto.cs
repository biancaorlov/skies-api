namespace SkiesApi.Models;

public class ActivitySummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string? City { get; set; }
    public DateTime StartsAt { get; set; }
    public string? LocationText { get; set; }
}