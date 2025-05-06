namespace Customers.DataModel.Models;

public class ListUserModel
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public string? Key { get; set; }

    public string FullName { get; set; } = null!;
}
