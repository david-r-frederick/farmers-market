using Core;
using Core.Entities;
using Core.Seeding;

public abstract class Seeder<TEntity> : ISeedDataProvider<TEntity> where TEntity : class, IBaseEntity
{
    public virtual async Task SeedAsync(IDatabaseContext dbContext)
    {
        var keys = GetSeedData();
        var entities = keys
            .Select(key => MapCustomFieldsToSeedData(key, dbContext.CreateBaseEntity<TEntity>(key)))
            .ToList();
        await dbContext.SeedEntitiesAsync(entities);
    }

    public abstract List<string> GetSeedData();

    public abstract TEntity MapCustomFieldsToSeedData(string seedKey, TEntity entity);
}
