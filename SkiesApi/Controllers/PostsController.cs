using Microsoft.AspNetCore.Mvc;
using SkiesApi.Services;

namespace SkiesApi.Controllers;

[ApiController]
[Route("api/posts")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    // GET /api/posts?q=travel&subjectId=8&departmentId=74&locationId=10&typeId=2&sort=modifiedDate&author=bior
    // (matchar din PDF) :contentReference[oaicite:4]{index=4}
    [HttpGet]
    public async Task<IActionResult> Search(
        [FromQuery] string? q,
        [FromQuery] int? subjectId,
        [FromQuery] int? departmentId,
        [FromQuery] int? locationId,
        [FromQuery] int? typeId,
        [FromQuery] string? sort,
        [FromQuery] string? author)
    {
        var result = await _postService.SearchAsync(q, subjectId, departmentId, locationId, typeId, sort, author);
        return Ok(result);
    }

    // GET /api/posts/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var post = await _postService.GetByIdAsync(id);
        if (post == null) return NotFound();
        return Ok(post);
    }
}