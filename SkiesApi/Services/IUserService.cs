using SkiesApi.Models;

namespace SkiesApi.Services;

public interface IUserService
{
    Task<UserProfileDto?> GetUserAsync(string username);
}