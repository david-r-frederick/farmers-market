namespace Customers.DataModel.Entities;

using Core;
using Microsoft.AspNetCore.Identity;

[SQLTable("Auth", "UserRole")]
public class UserRole : IdentityUserRole<int>
{
}
