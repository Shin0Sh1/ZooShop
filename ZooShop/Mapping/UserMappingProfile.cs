using AutoMapper;
using ZooShop.Dtos;
using ZooShop.Dtos.CreateDtos;
using ZooShop.Entities;

namespace ZooShop.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}