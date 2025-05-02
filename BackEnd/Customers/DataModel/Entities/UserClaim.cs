namespace Customers.DataModel.Entities;

using Core;
using Microsoft.AspNetCore.Identity;

[SQLTable("Auth", "UserClaim")]
public class UserClaim : IdentityUserClaim<int>
{
}
