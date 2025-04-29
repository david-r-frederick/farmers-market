namespace Customers.Repository;

using Core.Models;
using Customers.DataModel.Entities;

public interface IUsersRepository
{
    Task<User?> GetByIdAsync(int id);

    Task<List<User>> GetAllAsync(Paging paging);

    Task<int> AddAsync(User model);

    Task UpdateAsync(User model);

    Task DeleteAsync(int id);
}
