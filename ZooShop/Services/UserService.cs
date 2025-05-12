using ZooShop.Dtos;
using ZooShop.Entities;
using ZooShop.Interfaces;
using ZooShop.Repositories;

namespace ZooShop.Services;

public class UserService(IUserRepository userRepository, IHashService hashService) : IUserService
{
    public async Task<Guid> AddUserAsync(CreateUserDto user)
    {
        var userId = Guid.NewGuid();

        var userNickname = user.Nickname ?? user.Email;

        var userHashedPassword = hashService.Hash(user.Password);

        var userCreateResult = new User(id: userId, nickname: userNickname, password: userHashedPassword,
            email: user.Email,
            address: user.Address);

        await userRepository.AddAsync(userCreateResult);
        await userRepository.SaveChangesAsync();

        return userId;
    }
}