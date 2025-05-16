using Microsoft.EntityFrameworkCore;
using ZooShop.Configurations;
using ZooShop.Entities;
using ZooShop.Interfaces;

namespace ZooShop.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ZooShopContext _context;

    public UserRepository(ZooShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Order?> GetOrderByIdAsync(Guid orderId, Guid userId)
    {
        return await _context.Users.Where(u => u.Id == userId).SelectMany(u => u.Orders)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }
}