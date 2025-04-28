namespace Core;

using System.Threading.Tasks;
using Core.Models;

public abstract class Repository<T> : IRepository<T> where T : BaseModel
{
    protected readonly IDbContextFactoryWrapper _dbFactory;

    protected Repository(IDbContextFactoryWrapper dbContextFactoryWrapper)
    {
        _dbFactory = dbContextFactoryWrapper;
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        using var context = _dbFactory.GetContext();
        return await context.Set<T>().FindAsync(id);
    }

    public virtual async Task AddAsync(T entity)
    {
        using var context = _dbFactory.GetContext();
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        using var context = _dbFactory.GetContext();
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(int id)
    {
        using var context = _dbFactory.GetContext();
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}