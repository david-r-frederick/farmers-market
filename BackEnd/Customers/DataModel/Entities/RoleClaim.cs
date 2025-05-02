namespace Customers.DataModel.Entities;

using Core;
using Microsoft.AspNetCore.Identity;

[SQLTable("Auth", "RoleClaim")]
public class RoleClaim : IdentityRoleClaim<int>
{
}
