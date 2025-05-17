using ZooShop.Entities;

namespace ZooShop.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserWithOrdersAsync(Guid userId);
    Task<Order?> GetOrderByIdAsync(Guid orderId, Guid userId);
}