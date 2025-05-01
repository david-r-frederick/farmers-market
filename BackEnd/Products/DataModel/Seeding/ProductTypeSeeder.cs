namespace Products.Seeders;

using Products.DataModel.Entities;

public class ProductTypeSeeder : Seeder<ProductType>
{
    public override List<string> GetSeedData() => ["General"];

    public override ProductType MapCustomFieldsToSeedData(string seedKey, ProductType productType)
    {
        productType.Name = seedKey;
        return productType;
    }
}