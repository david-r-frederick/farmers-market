namespace Core;

public interface IRepository<TEntity>
{
    Task<TEntity?> GetByIdAsync(int id);

    Task AddAsync(TEntity entity);
}
