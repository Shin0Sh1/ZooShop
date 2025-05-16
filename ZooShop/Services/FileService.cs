using ZooShop.Interfaces;

namespace ZooShop.Services;

public class FileService : IFileService
{
    public Guid SaveFile(IFormFile file)
    {
        var fileName = Guid.NewGuid();

        var filePath = Path.Combine($"{Environment.CurrentDirectory}{fileName}{Path.GetExtension(file.FileName)}");

        using var fileStream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(fileStream);

        return fileName;
    }
}