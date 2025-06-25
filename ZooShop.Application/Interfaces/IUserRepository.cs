using System.Linq.Expressions;
using ZooShop.Domain.Entities;

namespace ZooShop.Application.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserWithOrdersAsync(Guid userId);
    Task<Order?> GetOrderByIdAsync(Guid orderId, Guid userId);
    Task<List<Order>> GetOrderByFilterAsync(Expression<Func<Order, bool>> predicate);
}