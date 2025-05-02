namespace Customers.DataModel.Entities;

using Core;
using Microsoft.AspNetCore.Identity;

[SQLTable("Auth", "Role")]
public partial class Role : IdentityRole<int>
{
    public string Key { get; set; } = null!;
}
