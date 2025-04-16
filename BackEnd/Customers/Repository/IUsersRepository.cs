namespace Customers.Repository;

using Customers.DataModel.Entities;

public interface IUsersRepository
{
    Task<User?> GetByIdAsync(int id);

    Task AddAsync(User entity);

    Task UpdateAsync(User entity);

    Task DeleteAsync(int id);
}
