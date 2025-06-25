using AutoMapper;
using ZooShop.Application.Dtos;
using ZooShop.Application.Dtos.CreateDtos;
using ZooShop.Application.Dtos.DeleteDtos;
using ZooShop.Application.Dtos.RequestDtos;
using ZooShop.Application.Dtos.ResponseDtos;
using ZooShop.Application.Dtos.UpdateDtos;
using ZooShop.Application.Interfaces;
using ZooShop.Domain.Entities;
using ZooShop.Domain.Exceptions;

namespace ZooShop.Application.Services;

public class UserService(IUserRepository userRepository, IHashService hashService, IMapper mapper) : IUserService
{
    public async Task<OrderDto> GetOrderByIdAsync(GetOrderDto orderDto)
    {
        var orderResult = await userRepository.GetOrderByIdAsync(orderId: orderDto.OrderId, userId: orderDto.UserId) ??
                          throw new EntityNotFoundException("Заказ не найден");

        return mapper.Map<OrderDto>(orderResult);
    }

    public async Task<UserDto> GetUserByEmailAsync(String email)
    {
        var userResult = await userRepository.GetUserByEmailAsync(email) ??
                         throw new EntityNotFoundException("Пользователь не найден");
        return mapper.Map<UserDto>(userResult);
    }

    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
        var userResult = await userRepository.GetEntityByIdAsync(userId) ??
                         throw new EntityNotFoundException("Пользователь не найден");
        return mapper.Map<UserDto>(userResult);
    }

    public async Task<Guid> GetUserIdByEmailAsync(string email)
    {
        var id = await userRepository.GetEntityByFilterAndSelectAsync(c => c.Email == email, c => c.Id);
        if (id == Guid.Empty)
        {
            throw new EntityNotFoundException("Такого пользователя не существует");
        }

        return id;
    }

    public async Task<List<OrderDto>> GetOrdersByFilterAsync(GetOrderByFilterDto orderByFilterDto)
    {
        var order = await userRepository.GetOrderByFilterAsync(c => c.Status == orderByFilterDto.Status)
                    ?? throw new EntityNotFoundException("Заказ не найден");
        return mapper.Map<List<OrderDto>>(order);
    }

    public async Task<bool> CheckIfUserExistByEmailAsync(string email)
    {
        return await userRepository.GetEntityByFilterAsync(c => c.Email == email) != null;
    }

    public async Task<Guid> AddUserAsync(CreateUserDto user)
    {
        var userId = Guid.NewGuid();

        var userHashedPassword = hashService.Hash(user.Password);

        var createUserResult = new User(id: userId, nickname: user.Email, password: userHashedPassword,
            email: user.Email,
            address: null);

        await userRepository.AddAsync(createUserResult);
        await userRepository.SaveChangesAsync();

        return userId;
    }

    public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
    {
        var user = await userRepository.GetEntityByIdAsync(updateUserDto.Id) ??
                   throw new EntityNotFoundException("Пользователь не найден");

        user.Update(nickname: updateUserDto.Nickname,
            password: updateUserDto.Password, email: updateUserDto.Email,
            address: updateUserDto.Address);

        await userRepository.SaveChangesAsync();
    }

    public async Task<Guid> AddOrderItemAsync(CreateOrderItemDto orderItemDto)
    {
        var user = await userRepository.GetUserWithOrdersAsync(orderItemDto.UserId) ??
                   throw new EntityNotFoundException("Пользователь не найден");

        var orderItemId = Guid.NewGuid();

        var orderItem = new OrderItem(id: orderItemId, quantity: orderItemDto.Quantity,
            totalPrice: orderItemDto.TotalPrice);

        user.AddOrderItem(orderId: orderItemDto.OrderId, orderItem);

        await userRepository.SaveChangesAsync();

        return orderItemId;
    }

    public async Task UpdateOrderStatusAsync(UpdateOrderStatus updateOrderStatus)
    {
        var user = await userRepository.GetUserWithOrdersAsync(updateOrderStatus.UserId) ??
                   throw new EntityNotFoundException("Пользователь не найден");

        var order = user.Orders.FirstOrDefault(c => c.Id == updateOrderStatus.OrderId) ??
                    throw new EntityNotFoundException("Заказ не найден");

        order.Update(updateOrderStatus.OrderStatus);
        await userRepository.SaveChangesAsync();
    }

    public async Task DeleteOrderItemsAsync(DeleteOrderItemDto orderItemDto)
    {
        var user = await userRepository.GetUserWithOrdersAsync(orderItemDto.UserId) ??
                   throw new EntityNotFoundException("Пользователь не найден");

        user.DeleteOrderItems(orderItemDto.OrderId, orderItemDto.OrderItemIds);

        await userRepository.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        var user = await userRepository.GetEntityByIdAsync(userId) ??
                   throw new EntityNotFoundException("Пользователь не найден");

        userRepository.Remove(user);
        await userRepository.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(DeleteOrderDto orderDto)
    {
        var user = await userRepository.GetUserWithOrdersAsync(orderDto.UserId) ??
                   throw new EntityNotFoundException("Пользователь не найден");

        var order = user.Orders.FirstOrDefault(o => o.Id == orderDto.OrderId) ??
                    throw new EntityNotFoundException("Заказ не найден");

        user.DeleteOrder(order: order);

        await userRepository.SaveChangesAsync();
    }
}