namespace SkiesApi.Models;

public class UserProfileDto
{
    public string Username { get; set; } = "";
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public string? Department { get; set; }
    public string? Office { get; set; }
}