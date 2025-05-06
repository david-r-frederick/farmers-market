namespace Core.Seeding;

using Core;
using Core.Entities;

public interface ISeeder
{
    Task SeedAsync(IDatabaseContext dbContext);
}

public interface ISeedDataProvider<TEntity> : ISeeder where TEntity : class, IBaseEntity
{
    List<string> GetSeedData();

    TEntity MapCustomFieldsToSeedData(string seedKey, TEntity entity);
}