using SkiesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace SkiesApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUser(string username)
    {
        var user = await _userService.GetUserAsync(username);
        if (user == null) return NotFound();
        return Ok(user);
    }
}