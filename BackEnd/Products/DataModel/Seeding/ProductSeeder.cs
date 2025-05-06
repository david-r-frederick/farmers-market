namespace Products.Seeders;

using Core;
using Core.Repository;
using Products.DataModel.Entities;

public class ProductSeeder : Seeder<Product>
{
    private ISettingsRepository _settingsRepository;

    public ProductSeeder(ISettingsRepository settingsRepository)
    {
        _settingsRepository = settingsRepository;
    }

    public override async Task SeedAsync(IDatabaseContext context)
    {
        var seedSampleProductsSetting = await _settingsRepository.GetByKeyAsync("SeedSampleProducts");
        if (seedSampleProductsSetting is null || seedSampleProductsSetting.Value != "true")
        {
            return;
        }
        await base.SeedAsync(context);
    }

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