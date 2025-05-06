namespace Customers.DataModel.Models;

public class FullUserModel
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public string? Key { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleInitial { get; set; }

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Street1 { get; set; } = null!;

    public string? Street2 { get; set; }

    public string City { get; set; } = null!;

    public string County { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PostalCode { get; set; } = null!;
}
