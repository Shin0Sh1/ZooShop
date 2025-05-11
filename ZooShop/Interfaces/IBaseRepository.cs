using ZooShop.Entities;

namespace ZooShop.Interfaces;

public interface IBaseRepository<TEntity>where TEntity : BaseEntity
{
    Task AddAsync(TEntity entity);
    Task SaveChangesAsync();
}