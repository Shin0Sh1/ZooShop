namespace ZooShop.Interfaces;

public interface IConsultantService
{
    Task<Guid> GetConsultantIdByEmailAsync(string email);
}