namespace Customers.DataModel.Entities;

using Core;
using Microsoft.AspNetCore.Identity;

[SQLTable("Auth", "UserLogin")]
public class UserLogin : IdentityUserLogin<int>
{
}
