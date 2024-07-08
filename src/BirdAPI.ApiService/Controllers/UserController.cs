using BirdAPI.ApiService.Database.Models;
using BirdAPI.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BirdAPI.ApiService.Controllers;

[ApiController]
[Route("users")]
public class UserController(IUserRepository userRepository) : ControllerBase
{
    [HttpPost("create/fake")]
    public async Task<IActionResult> CreateFakeUsers(int count)
    {
        var userIds = await userRepository.AddFakeUsersAsync(count, CancellationToken.None);
        return Ok(userIds);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] string name)
    {
        var user = new User { Id = Guid.NewGuid(), Name = name };
        await userRepository.AddUserAsync(user, CancellationToken.None);
        return Ok(user.Id);
    }
}