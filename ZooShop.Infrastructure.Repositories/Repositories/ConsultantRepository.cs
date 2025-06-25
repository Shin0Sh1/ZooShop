using ZooShop.Application.Interfaces;
using ZooShop.Domain.Entities;
using ZooShop.Infrastructure.Data.Configurations;

namespace ZooShop.Infrastructure.Repositories.Repositories;

public class ConsultantRepository : GenericRepository<Consultant>, IConsultantRepository
{
    public ConsultantRepository(ZooShopContext context) : base(context)
    {
    }
}