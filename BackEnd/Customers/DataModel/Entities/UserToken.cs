namespace Customers.DataModel.Entities;

using Core;
using Microsoft.AspNetCore.Identity;

[SQLTable("Auth", "UserToken")]
public class UserToken : IdentityUserToken<int>
{
}
