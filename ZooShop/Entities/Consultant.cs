namespace ZooShop.Entities;

public class Consultant : BaseEntity
{
    public required string StaffCode { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateTime Birthday { get; set; }
}