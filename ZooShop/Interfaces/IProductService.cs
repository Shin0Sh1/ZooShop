using ZooShop.Dtos;
using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Dtos.UpdateDtos;

namespace ZooShop.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(Guid productId);
    Task<Guid> AddProductAsync(CreateProductDto product);
    Task UpdateProductAsync(UpdateProductDto product);
    Task DeleteProductAsync(Guid productId);
}