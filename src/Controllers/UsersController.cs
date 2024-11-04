using Microsoft.AspNetCore.Mvc;
using connect.Users.Models;
using connect.Users.Services;

namespace connect.Users.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    public UsersController(UserService userService) => _userService = userService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserModel user)
    {
        await _userService.CreateAsync(user);
        return NoContent();
    }
}