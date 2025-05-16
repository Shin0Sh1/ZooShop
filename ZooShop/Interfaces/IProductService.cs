using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Dtos.UpdateDtos;

namespace ZooShop.Interfaces;

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