using Microsoft.AspNetCore.Mvc;
using connect.Users.Models;
using connect.Users.Services;
using connect.Users.Utilities;

namespace connect.Users.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    public UsersController(UserService userService) => _userService = userService;
    private readonly AppErrorUtility appError = new();
    [HttpGet]
    public async Task<ActionResult<AppResult<List<UserModel>>>> Get()
    {
        try
        {
            var users = await _userService.GetAllAsync();
            var result = new AppResult<List<UserModel>> { Data = users };
            return Ok(result);
        }
        catch (Exception e)
        {
            return appError.SendServerError(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserModel user)
    {
        try
        {
            await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);

        }
        catch (Exception e)
        {
            return appError.SendServerError(e.Message);

        }
    }
}