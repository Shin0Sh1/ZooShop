using Microsoft.AspNetCore.Http;
using ZooShop.Application.Dtos.ResponseDtos;

namespace ZooShop.Application.Interfaces;

public interface IFileService
{
    string? GetImageExtension(Guid imageId);
    Task<ImageDto> GetImageAsync(string imageName);
    Task<string> SaveImageAsync(IFormFile file);
    void DeleteImage(string imageName);
}