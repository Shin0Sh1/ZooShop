using Microsoft.Extensions.DependencyInjection;
using ZooShop.Application.Interfaces;
using ZooShop.Application.Mapping;
using ZooShop.Application.Services;

namespace ZooShop.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddScoped<IHashService, HashService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IConsultantService, ConsultantService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IUserService, UserService>();
        services.AddAutoMapper(typeof(ProductMappingProfile), typeof(OrderMappingProfile), typeof(UserMappingProfile));

    }
}