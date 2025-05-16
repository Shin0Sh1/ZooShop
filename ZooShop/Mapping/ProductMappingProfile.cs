using AutoMapper;
using ZooShop.Dtos;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Entities;

namespace ZooShop.Mapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}