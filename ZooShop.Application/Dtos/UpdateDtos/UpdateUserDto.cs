namespace ZooShop.Application.Dtos.UpdateDtos;

public class UpdateUserDto
{
    public Guid Id { get; init; }
    public string? Nickname { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? Address { get; init; }
}