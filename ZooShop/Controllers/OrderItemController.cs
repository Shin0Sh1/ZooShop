using Microsoft.AspNetCore.Mvc;
using ZooShop.Application.Dtos.CreateDtos;
using ZooShop.Application.Dtos.DeleteDtos;
using ZooShop.Application.Interfaces;

namespace ZooShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddOrderItem(CreateOrderItemDto orderItem)
    {
        var orderItemId = await userService.AddOrderItemAsync(orderItem);
        return Ok(orderItemId);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrderItem(DeleteOrderItemDto orderItemDto)
    {
        await userService.DeleteOrderItemsAsync(orderItemDto);
        return NoContent();
    }
}