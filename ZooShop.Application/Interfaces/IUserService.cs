using ZooShop.Application.Dtos;
using ZooShop.Application.Dtos.CreateDtos;
using ZooShop.Application.Dtos.DeleteDtos;
using ZooShop.Application.Dtos.RequestDtos;
using ZooShop.Application.Dtos.ResponseDtos;
using ZooShop.Application.Dtos.UpdateDtos;

namespace ZooShop.Application.Interfaces;

public interface IUserService
{
    Task<List<OrderDto>> GetOrdersByFilterAsync(GetOrderByFilterDto orderByFilterDto);
    Task<Guid> GetUserIdByEmailAsync(string email);
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<bool> CheckIfUserExistByEmailAsync(string name);
    Task<OrderDto> GetOrderByIdAsync(GetOrderDto orderDto);
    Task<Guid> AddUserAsync(CreateUserDto user);
    Task<Guid> AddOrderItemAsync(CreateOrderItemDto orderItemDto);
    Task UpdateOrderStatusAsync(UpdateOrderStatus updateOrderStatus);
    Task UpdateUserAsync(UpdateUserDto updateUserDto);
    Task DeleteUserAsync(Guid userId);
    Task DeleteOrderAsync(DeleteOrderDto orderDto);
    Task DeleteOrderItemsAsync(DeleteOrderItemDto orderItemDto);
}