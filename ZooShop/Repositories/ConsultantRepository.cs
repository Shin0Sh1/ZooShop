using ZooShop.Configurations;
using ZooShop.Entities;
using ZooShop.Interfaces;

namespace ZooShop.Repositories;

public class ConsultantRepository : GenericRepository<Consultant>, IConsultantRepository
{
    public ConsultantRepository(ZooShopContext context) : base(context)
    {
    }
}