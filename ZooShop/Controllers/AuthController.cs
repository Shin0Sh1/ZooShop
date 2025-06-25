using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ZooShop.Application.Dtos;
using ZooShop.Application.Interfaces;
using ZooShop.Options;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ZooShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtOptions _options;
    private readonly IUserService _userService;
    private readonly IConsultantService _consultantService;

    public AuthController(UserManager<IdentityUser> userManager, IOptions<JwtOptions> options, IUserService userService, IConsultantService consultantService)
    {
        _userManager = userManager;
        _userService = userService;
        _consultantService = consultantService;
        _options = options.Value;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return Unauthorized();
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }.Union(userRoles.Select(role => new Claim(ClaimTypes.Role, role))).ToList();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
        var token = new JwtSecurityToken(issuer: _options.Issuer,
            audience: _options.Audience,
            expires: DateTime.UtcNow.AddHours(_options.ExpiresHours),
            claims: authClaims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
        if (loginDto.IsConsultant)
        {
            var consultantId = await _consultantService.GetConsultantIdByEmailAsync(loginDto.Email);
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), userId = consultantId });
        }
      
        var userId = await _userService.GetUserIdByEmailAsync(loginDto.Email);

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), userId });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var isUserExist = await _userService.CheckIfUserExistByEmailAsync(registerDto.Email);
        if (isUserExist)
        {
            return Conflict("Такой пользователь уже существует");
        }

        var user = new IdentityUser
        {
            UserName = registerDto.Email,
        };
        var result = _userManager.CreateAsync(user, registerDto.Password).Result;
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        var roleResult = await _userManager.AddToRoleAsync(user, "User");
        if (!roleResult.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, roleResult.Errors);
        }

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        authClaims.AddRange((await _userManager.GetRolesAsync(user))
            .Select(r => new Claim(ClaimTypes.Role, r)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
        var tokenDescriptor = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            expires: DateTime.UtcNow.AddHours(_options.ExpiresHours),
            claims: authClaims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        await _userService.AddUserAsync(registerDto);
        return CreatedAtAction(nameof(Register), new { id = user.Id, token = tokenString });
    }
}