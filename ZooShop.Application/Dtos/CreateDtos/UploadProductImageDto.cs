using Microsoft.AspNetCore.Http;

namespace ZooShop.Application.Dtos.CreateDtos;

public class UploadProductImageDto
{
    public Guid ProductId { get; init; }
    public required IFormFile Image { get; init; }
}