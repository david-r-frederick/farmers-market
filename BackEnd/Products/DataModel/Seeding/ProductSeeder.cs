namespace Products.Seeders;

using Products.DataModel.Entities;

public class ProductSeeder : Seeder<Product>
{
    public override List<string> GetSeedData() => ["General"];

    public override Product MapCustomFieldsToSeedData(string seedKey, Product product)
    {
        product.Name = seedKey;
        product.Description = $"Description for {seedKey}";
        product.TypeId = 1;
        product.Price = 1.5;
        return product;
    }
}