namespace Core;

using Core.Entities;
using Microsoft.EntityFrameworkCore;

public interface IDatabaseContext : IDisposable
{
    DbSet<T> Set<T>() where T : class;

    Task<int> SaveChangesAsync(CancellationToken token = default);

    Task SeedEntitiesAsync<T>(IEnumerable<T> entities) where T : BaseEntity;

    T CreateBaseEntity<T>(string key) where T : BaseEntity;
}
