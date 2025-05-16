using Microsoft.AspNetCore.Mvc;
using ZooShop.Dtos;
using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Dtos.UpdateDtos;
using ZooShop.Interfaces;

namespace ZooShop.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductDto product)
    {
        var productId = await productService.AddProductAsync(product);
        return Ok(productId);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto product)
    {
        await productService.UpdateProductAsync(product);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        await productService.DeleteProductAsync(id);
        return NoContent();
    }

    public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    {
        
    }
}