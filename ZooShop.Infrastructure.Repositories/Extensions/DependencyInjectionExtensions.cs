using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZooShop.Application.Interfaces;
using ZooShop.Infrastructure.Data.Configurations;
using ZooShop.Infrastructure.Repositories.Repositories;

namespace ZooShop.Infrastructure.Repositories.Extensions;

public static class DependencyInjectionExtensions
{
    public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IConsultantRepository, ConsultantRepository>();
        
        services.AddNpgsql<ZooShopContext>(configuration.GetConnectionString("DefaultConnection"));
        services.AddNpgsql<IdentityDbContext>(configuration.GetConnectionString("IdentityConnection"));

    }
}