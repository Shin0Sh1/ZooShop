using ZooShop.Dtos;
using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.DeleteDtos;
using ZooShop.Dtos.RequestDtos;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Dtos.UpdateDtos;

namespace ZooShop.Interfaces;

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