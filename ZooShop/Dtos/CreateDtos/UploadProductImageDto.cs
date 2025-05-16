namespace ZooShop.Dtos.CreateDtos;

public class UploadProductImageDto
{
    public Guid ProductId { get; init; }
    public required IFormFile Image { get; init; }
}