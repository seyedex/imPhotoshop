namespace imPhotoshop.Domain.Entities;

public class User : BaseAuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
