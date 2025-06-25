using AutoMapper;
using ZooShop.Application.Dtos.CreateDtos;
using ZooShop.Application.Dtos.ResponseDtos;
using ZooShop.Domain.Entities;

namespace ZooShop.Application.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, CreateUserDto>();
        CreateMap<User, UserDto>();
    }
}