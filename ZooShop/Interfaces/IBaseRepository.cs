﻿using System.Linq.Expressions;
using ZooShop.Entities;

namespace ZooShop.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetEntityByFilterAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> GetEntityByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    void Remove(TEntity entity);
    Task SaveChangesAsync();
}