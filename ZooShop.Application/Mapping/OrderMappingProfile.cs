using AutoMapper;
using ZooShop.Application.Dtos.ResponseDtos;
using ZooShop.Domain.Entities;

namespace ZooShop.Application.Mapping;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>();
    }
}