using AutoMapper;
using Microsoft.Extensions.Options;
using ZooShop.Dtos;
using ZooShop.Dtos.CreateDtos;
using ZooShop.Dtos.ResponseDtos;
using ZooShop.Dtos.UpdateDtos;
using ZooShop.Entities;
using ZooShop.Exceptions;
using ZooShop.Interfaces;
using ZooShop.Options;

namespace ZooShop.Services;

public class ProductService(
    IProductRepository productRepository,
    IMapper mapper,
    IFileService fileService,
    IOptions<ZooShopOptions> options)
    : IProductService
{
    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var allProductsResult = await productRepository.GetAllAsync();
        return mapper.Map<List<ProductDto>>(allProductsResult);
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid productId)
    {
        var productResult = await productRepository.GetEntityByIdAsync(productId) ??
                            throw new EntityNotFoundException("Товар не найден");

        return mapper.Map<ProductDto>(productResult);
    }

    public async Task<Guid> AddProductAsync(CreateProductDto product)
    {
        var productId = Guid.NewGuid();
        
        

        var createProductResult = new Product(id: productId, name: product.Name, description: product.Description,
            price: product.Price, quantity: product.Quantity, imageUrl: null, category: product.Category);

        await productRepository.AddAsync(createProductResult);
        await productRepository.SaveChangesAsync();

        return productId;
    }

    public async Task UpdateProductAsync(UpdateProductDto product)
    {
        var productResult = await productRepository.GetEntityByIdAsync(product.Id) ??
                            throw new EntityNotFoundException("Товар не найден");

        productResult.Update(name: product.Name, description: product.Description, price: product.Price,
            quantity: product.Quantity, imageUrl: product.ImageUrl, category: product.Category);

        await productRepository.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Guid productId)
    {
        var productResult = await productRepository.GetEntityByIdAsync(productId) ??
                            throw new EntityNotFoundException("Товар не найден");

        productRepository.Remove(productResult);

        await productRepository.SaveChangesAsync();
    }
}