using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.RequestDtos;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Dtos.UpdateDtos;

namespace ZooShop.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<OrderDto> GetOrderByIdAsync(GetOrderDto orderDto);
    Task<Guid> AddUserAsync(CreateUserDto user);
    Task<Guid> AddOrderAsync(CreateOrderDto order);
    Task UpdateUserAsync(UpdateUserDto updateUserDto);
    Task DeleteUserAsync(Guid userId);
}