using AutoMapper;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Entities;

namespace ZooShop.Mapping;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>();
    }
}