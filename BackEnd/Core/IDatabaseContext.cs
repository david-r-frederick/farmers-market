namespace Core;

using Microsoft.EntityFrameworkCore;

public interface IDatabaseContext : IDisposable
{
    DbSet<T> Set<T>() where T : class;

    Task<int> SaveChangesAsync(CancellationToken token);
}
