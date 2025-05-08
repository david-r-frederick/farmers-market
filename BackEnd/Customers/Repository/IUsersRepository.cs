namespace Customers.Repository;

using Core.DataModel.Models;
using Customers.DataModel.Entities;
using Customers.DataModel.Models;

public interface IUsersRepository
{
    Task<FullUserModel?> GetByIdAsync(int id);

    Task<List<ListUserModel>> GetAllAsync(Paging paging);

    Task<User> AddAsync(FullUserModel model, string password);

    Task UpdateAsync(FullUserModel model);

    Task DeleteAsync(int id);

    Task<bool> LogInAsync(string userName, string password);
}
