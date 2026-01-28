using SkiesApi.Models;

namespace SkiesApi.Services;

public interface IActivityService
{
    Task<IEnumerable<ActivitySummaryDto>> ListAsync(bool? myCity, string? city);
    Task<ActivityDetailDto?> GetByIdAsync(int id);
}