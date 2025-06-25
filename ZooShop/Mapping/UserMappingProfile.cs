using AutoMapper;
using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Entities;

namespace ZooShop.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, CreateUserDto>();
        CreateMap<User, UserDto>();
    }
}