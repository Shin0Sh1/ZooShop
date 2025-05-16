using ZooShop.Entities;

namespace ZooShop.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<Order?> GetOrderByIdAsync(Guid orderId, Guid userId);
}