using Microsoft.AspNetCore.Mvc;
using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.RequestDtos;
using ZooShop.Interfaces;

namespace ZooShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOrderById([FromQuery] GetOrderDto getOrderDto)
    {
        var order = await userService.GetOrderByIdAsync(getOrderDto);
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderDto createOrderDto)
    {
        var orderId = await userService.AddOrderAsync(createOrderDto);
        return Ok(orderId);
    }
}