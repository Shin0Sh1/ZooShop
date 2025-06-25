using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZooShop.Application.Dtos.CreateDtos;
using ZooShop.Application.Dtos.UpdateDtos;
using ZooShop.Application.Interfaces;

namespace ZooShop.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id)
    {
        var product = await productService.GetProductByIdAsync(id);
        return Ok(product);
    }

    [HttpGet("image/{imageName}")]
    public async Task<IActionResult> GetImage([FromRoute] string imageName)
    {
        var image = await productService.GetProductImageAsync(imageName);
        return new FileContentResult(image.Image, "application/octet-stream")
        {
            FileDownloadName = imageName
        };
    }

    [Authorize(Roles = "Consultant")]
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductDto product)
    {
        var productId = await productService.AddProductAsync(product);
        return Ok(productId);
    }

    [Authorize(Roles = "Consultant")]
    [HttpPost("uploadImage")]
    public async Task<IActionResult> UploadImage([FromForm] UploadProductImageDto productImage)
    {
        var imageUrl = await productService.UploadImageAsync(productImage);
        return Ok(imageUrl);
    }

    [Authorize(Roles = "Consultant")]
    [HttpPatch]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto product)
    {
        await productService.UpdateProductAsync(product);
        return NoContent();
    }

    [Authorize(Roles = "Consultant")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        await productService.DeleteProductAsync(id);
        return NoContent();
    }
}