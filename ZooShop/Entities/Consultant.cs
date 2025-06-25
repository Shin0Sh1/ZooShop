namespace ZooShop.Entities;

public class Consultant : BaseEntity
{
    public string StaffCode { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? MiddleName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime Birthday { get; private set; }

    public Consultant(Guid id, string staffCode, string firstName, string lastName, string? middleName,
        DateTime birthday, string email, string password) : base(id)
    {
        StaffCode = staffCode;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Birthday = birthday;
        Email = email;
        Password = password;
    }

    private Consultant() : base(Guid.NewGuid())
    {
    }
}