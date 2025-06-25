using ZooShop.Dtos.CreateDtos;

namespace ZooShop.Dtos;

public class LoginDto : CreateUserDto
{
    public bool IsConsultant { get; init; }
}