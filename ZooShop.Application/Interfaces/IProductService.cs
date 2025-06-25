using ZooShop.Application.Dtos.CreateDtos;
using ZooShop.Application.Dtos.ResponseDtos;
using ZooShop.Application.Dtos.UpdateDtos;

namespace ZooShop.Application.Interfaces;

public interface IProductService
{
    Task<ImageDto> GetProductImageAsync(string imageName);
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(Guid productId);
    Task<Guid> AddProductAsync(CreateProductDto product);
    Task UpdateProductAsync(UpdateProductDto product);
    Task<string> UploadImageAsync(UploadProductImageDto productImage);
    Task DeleteProductAsync(Guid productId);
}