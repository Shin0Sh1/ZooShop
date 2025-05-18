using AutoMapper;
using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.DeleteDtos;
using ZooShop.Dtos.RequestDtos;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Dtos.UpdateDtos;
using ZooShop.Entities;
using ZooShop.Exceptions;
using ZooShop.Interfaces;

namespace ZooShop.Services;

public class UserService(IUserRepository userRepository, IHashService hashService, IMapper mapper) : IUserService
{
    public async Task<OrderDto> GetOrderByIdAsync(GetOrderDto orderDto)
    {
        var orderResult = await userRepository.GetOrderByIdAsync(orderId: orderDto.OrderId, userId: orderDto.UserId) ??
                          throw new EntityNotFoundException("Заказ не найден");

        return mapper.Map<OrderDto>(orderResult);
    }

    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
        var userResult = await userRepository.GetEntityByIdAsync(userId) ??
                         throw new EntityNotFoundException("Пользователь не найден");
        return mapper.Map<UserDto>(userResult);
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


    public async Task<Guid> AddOrderAsync(CreateOrderDto order)
    {
        var orderId = Guid.NewGuid();
        var orderItemId = Guid.NewGuid();

        var user = await userRepository.GetEntityByIdAsync(order.UserId) ??
                   throw new EntityNotFoundException("Пользователь не найден");

        var orderItems = order.OrderItems.Select(o =>
                new OrderItem(id: orderItemId, productId: o.ProductId, quantity: o.Quantity, totalPrice: o.TotalPrice))
            .ToList();

        var createOrderResult = new Order(id: orderId, orderDate: DateTime.UtcNow, orderItems: orderItems);

        user.AddOrder(createOrderResult);

        await userRepository.SaveChangesAsync();

        return orderId;
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

    public async Task AddOrderItemsAsync()
    {
    }

    public async Task DeleteOrderItemsAsync()
    {
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