using ZooShop.Configurations;
using ZooShop.Entities;
using ZooShop.Interfaces;

namespace ZooShop.Repositories;

public abstract class GenericRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ZooShopContext _context;

    public GenericRepository(ZooShopContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}