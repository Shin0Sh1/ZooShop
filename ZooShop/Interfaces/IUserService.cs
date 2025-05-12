using ZooShop.Dtos;

namespace ZooShop.Interfaces;

public interface IUserService
{
    Task<Guid> AddUserAsync(CreateUserDto user);
}