using SkiesApi.Models;

namespace SkiesApi.Services;

public interface IPostService
{
    Task<IEnumerable<PostSummaryDto>> SearchAsync(
        string? q,
        int? subjectId,
        int? departmentId,
        int? locationId,
        int? typeId,
        string? sort,
        string? author);

    Task<PostDetailDto?> GetByIdAsync(int id);
}