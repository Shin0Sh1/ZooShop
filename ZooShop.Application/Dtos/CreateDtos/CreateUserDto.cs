﻿namespace ZooShop.Application.Dtos.CreateDtos;

public class CreateUserDto
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}