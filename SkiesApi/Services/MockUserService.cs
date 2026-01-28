using SkiesApi.Models;

namespace SkiesApi.Services;

public class MockUserService : IUserService
{
    public Task<UserProfileDto?> GetUserAsync(string username)
    {
        return Task.FromResult<UserProfileDto?>(new UserProfileDto
        {
            Username = username,
            Email = $"{username}@sigma.se",
            Mobile = "070-000 00 00",
            Department = "Mock Department",
            Office = "Mock Office"
        });
    }
}