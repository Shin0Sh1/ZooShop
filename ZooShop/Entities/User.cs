namespace ZooShop.Entities;

public class User : BaseEntity
{
    public required string Nickname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? Address { get; set; }
    public DateTime Birthday { get; set; }
    
}