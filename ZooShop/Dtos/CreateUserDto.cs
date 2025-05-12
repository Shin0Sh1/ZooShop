namespace ZooShop.Dtos;

public class CreateUserDto
{
    public string? Nickname { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public string? Address { get; init; }
}