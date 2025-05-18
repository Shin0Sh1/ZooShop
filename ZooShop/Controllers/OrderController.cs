using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.DeleteDtos;
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

    [Authorize(Roles = "User")]
    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderDto createOrderDto)
    {
        var orderId = await userService.AddOrderAsync(createOrderDto);
        return Ok(orderId);
    }

    [Authorize(Roles = "User")]
    [HttpDelete]
    public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderDto getOrderDto)
    {
        await userService.DeleteOrderAsync(getOrderDto);
        return NoContent();
    }
}