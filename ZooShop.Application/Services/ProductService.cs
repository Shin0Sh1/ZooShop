using AutoMapper;
using ZooShop.Application.Dtos.CreateDtos;
using ZooShop.Application.Dtos.ResponseDtos;
using ZooShop.Application.Dtos.UpdateDtos;
using ZooShop.Application.Interfaces;
using ZooShop.Domain.Entities;
using ZooShop.Domain.Exceptions;

namespace ZooShop.Application.Services;

public class ProductService(
    IProductRepository productRepository,
    IMapper mapper,
    IFileService fileService)
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

    public async Task<ImageDto> GetProductImageAsync(string imageName)
    {
        return await fileService.GetImageAsync(imageName);
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

    public async Task<string> UploadImageAsync(UploadProductImageDto productImage)
    {
        var product = await productRepository.GetEntityByIdAsync(productImage.ProductId) ??
                      throw new EntityNotFoundException("Такого продукта не существует");

        var imageUrl = await fileService.SaveImageAsync(productImage.Image);
        product.Update(imageUrl: imageUrl);

        await productRepository.SaveChangesAsync();
        return imageUrl;
    }

    public async Task UpdateProductAsync(UpdateProductDto product)
    {
        var productResult = await productRepository.GetEntityByIdAsync(product.Id) ??
                            throw new EntityNotFoundException("Товар не найден");

        productResult.Update(name: product.Name, description: product.Description, price: product.Price,
            quantity: product.Quantity, imageUrl: null, category: product.Category);

        await productRepository.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Guid productId)
    {
        var productResult = await productRepository.GetEntityByIdAsync(productId) ??
                            throw new EntityNotFoundException("Товар не найден");

        productRepository.Remove(productResult);

        await productRepository.SaveChangesAsync();
        if (productResult.ImageUrl is not null)
        {
            fileService.DeleteImage(Path.GetFileName(new Uri(productResult.ImageUrl).AbsolutePath));
        }
    }
}