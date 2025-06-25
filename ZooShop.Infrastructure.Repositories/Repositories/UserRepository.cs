using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ZooShop.Application.Interfaces;
using ZooShop.Domain.Entities;
using ZooShop.Infrastructure.Data.Configurations;

namespace ZooShop.Infrastructure.Repositories.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ZooShopContext _context;

    public UserRepository(ZooShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserWithOrdersAsync(Guid userId)
    {
        return await _context.Users
            .Include(u => u.Orders)
            .ThenInclude(u => u.OrderItems)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<List<Order>> GetOrderByFilterAsync(Expression<Func<Order, bool>> predicate)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(Guid orderId, Guid userId)
    {
        return await _context.Users.Where(u => u.Id == userId).SelectMany(u => u.Orders)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }
}