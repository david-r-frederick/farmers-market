namespace Core;

using System.Threading.Tasks;
using Core.DataModel.Entities;

public abstract class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly IDatabaseContext _databaseContext;

    protected Repository(IDatabaseContext context)
    {
        _databaseContext = context;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _databaseContext.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _databaseContext.Set<T>().AddAsync(entity);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _databaseContext.Set<T>().Update(entity);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _databaseContext.Set<T>().Remove(entity);
            await _databaseContext.SaveChangesAsync();
        }
    }
}