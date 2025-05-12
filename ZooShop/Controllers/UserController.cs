using Microsoft.AspNetCore.Mvc;
using ZooShop.Dtos;
using ZooShop.Entities;
using ZooShop.Interfaces;

namespace ZooShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserDto user)
    {
        var userId = await userService.AddUserAsync(user);
        return Ok(userId);
    }  
}