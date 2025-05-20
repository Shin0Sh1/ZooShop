using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.DeleteDtos;
using ZooShop.Dtos.RequestDtos;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Dtos.UpdateDtos;

namespace ZooShop.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<bool> CheckIfUserExistByEmailAsync(string name);
    Task<OrderDto> GetOrderByIdAsync(GetOrderDto orderDto);
    Task<Guid> AddUserAsync(CreateUserDto user);
    Task<Guid> AddOrderItemAsync(CreateOrderItemDto orderItemDto);
    Task UpdateUserAsync(UpdateUserDto updateUserDto);
    Task DeleteUserAsync(Guid userId);
    Task DeleteOrderAsync(DeleteOrderDto orderDto);
    Task DeleteOrderItemsAsync(DeleteOrderItemDto orderItemDto);
}