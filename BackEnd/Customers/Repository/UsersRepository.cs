namespace Customers.Repository;

using Core;
using Customers.DataModel.Entities;

public class UsersRepository : IUsersRepository
{
    protected readonly IDatabaseContext _databaseContext;

    public UsersRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _databaseContext.Set<User>().FindAsync(id);
    }

    public async Task AddAsync(User entity)
    {
        await _databaseContext.Set<User>().AddAsync(entity);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        _databaseContext.Set<User>().Update(entity);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _databaseContext.Set<User>().Remove(entity);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
