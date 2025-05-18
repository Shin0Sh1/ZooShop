using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ZooShop.Configurations;
using ZooShop.Entities;
using ZooShop.Interfaces;

namespace ZooShop.Repositories;

public abstract class GenericRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ZooShopContext _context;

    protected GenericRepository(ZooShopContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetEntityByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(u => u.Id == id);
    }
    public async Task<TEntity?> GetEntityByFilterAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}