using ZooShop.Application.Interfaces;
using ZooShop.Domain.Entities;
using ZooShop.Infrastructure.Data.Configurations;

namespace ZooShop.Infrastructure.Repositories.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ZooShopContext context) : base(context)
    {
    }
}