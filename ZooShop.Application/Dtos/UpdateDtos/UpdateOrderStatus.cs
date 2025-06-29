﻿using ZooShop.Domain.Enums;

namespace ZooShop.Application.Dtos.UpdateDtos;

public class UpdateOrderStatus
{
    public Guid UserId { get; init; }
    public Guid OrderId { get; init; }
    public OrderStatus OrderStatus { get; init; }
}