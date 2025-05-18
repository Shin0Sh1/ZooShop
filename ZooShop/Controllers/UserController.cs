using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooShop.Dtos.UpdateDtos;
using ZooShop.Interfaces;

namespace ZooShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid userId)
    {
        var user = await userService.GetUserByIdAsync(userId);
        return Ok(user);
    }

    [Authorize(Roles = "User")]
    [HttpPatch]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto user)
    {
        await userService.UpdateUserAsync(user);
        return NoContent();
    }

    [Authorize(Roles = "User")]
    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
    {
        await userService.DeleteUserAsync(userId);
        return NoContent();
    }
}