using Microsoft.AspNetCore.Mvc;
using SkiesApi.Services;

namespace SkiesApi.Controllers;

[ApiController]
[Route("api/activities")]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivitiesController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    // GET /api/activities?myCity=true OR /api/activities?city=Göteborg
    [HttpGet]
    public async Task<IActionResult> List([FromQuery] bool? myCity, [FromQuery] string? city)
    {
        var result = await _activityService.ListAsync(myCity, city);
        return Ok(result);
    }

    // GET /api/activities/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var activity = await _activityService.GetByIdAsync(id);
        if (activity == null) return NotFound();
        return Ok(activity);
    }
}