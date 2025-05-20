using Microsoft.AspNetCore.Mvc;
using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.DeleteDtos;
using ZooShop.Entities;
using ZooShop.Interfaces;

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