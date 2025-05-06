namespace Customers.DataModel.Seeding;

using Customers.DataModel.Entities;

public class RoleSeeder : Seeder<Role>
{
    public override List<string> GetSeedData() => [ "Full Administrator", "Vendor" ];

    public override Role MapCustomFieldsToSeedData(string seedKey, Role role)
    {
        role.Name = seedKey;
        role.NormalizedName = seedKey.ToUpper();
        return role;
    }
}
