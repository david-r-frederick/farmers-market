namespace Core;

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;

public interface IDatabaseContext : IDisposable, IDataProtectionKeyContext
{
    DbSet<T> Set<T>() where T : class;

    Task<int> SaveChangesAsync(CancellationToken token = default);

    Task SeedEntitiesAsync<T>(IEnumerable<T> entities) where T : class, IBaseEntity;

    T CreateBaseEntity<T>(string key) where T : class, IBaseEntity;
}
