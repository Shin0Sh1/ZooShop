using ZooShop.Configurations;
using ZooShop.Entities;
using ZooShop.Interfaces;

namespace ZooShop.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ZooShopContext context) : base(context)
    {
    }
    
    
}