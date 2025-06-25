using ZooShop.Application.Dtos.CreateDtos;

namespace ZooShop.Application.Dtos;

public class LoginDto : CreateUserDto
{
    public bool IsConsultant { get; init; }
}