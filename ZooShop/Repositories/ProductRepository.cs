using ZooShop.Configurations;
using ZooShop.Entities;
using ZooShop.Interfaces;

namespace ZooShop.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ZooShopContext context) : base(context)
    {
    }
}