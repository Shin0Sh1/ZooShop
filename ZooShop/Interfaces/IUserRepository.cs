using System.Linq.Expressions;
using ZooShop.Entities;

namespace ZooShop.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserWithOrdersAsync(Guid userId);
    Task<Order?> GetOrderByIdAsync(Guid orderId, Guid userId);
    Task<List<Order>> GetOrderByFilterAsync(Expression<Func<Order, bool>> predicate);
}