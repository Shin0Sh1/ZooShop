namespace ZooShop.Dtos.ResponseDtos;

public class UserDto
{
    public required string Nickname { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public string? Address { get; init; }
}