using Microsoft.AspNetCore.Mvc;
using ZooShop.Application.Dtos;
using ZooShop.Application.Dtos.DeleteDtos;
using ZooShop.Application.Dtos.RequestDtos;
using ZooShop.Application.Dtos.UpdateDtos;
using ZooShop.Application.Interfaces;

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

    [HttpGet("filter")]
    public async Task<IActionResult> GetOrdersByFilter([FromQuery] GetOrderByFilterDto getOrderByFilterDto)
    {
        var orders = await userService.GetOrdersByFilterAsync(getOrderByFilterDto);
        return Ok(orders);
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatus updateOrderDto)
    {
        await userService.UpdateOrderStatusAsync(updateOrderDto);
        return NoContent();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderDto getOrderDto)
    {
        await userService.DeleteOrderAsync(getOrderDto);
        return NoContent();
    }
}