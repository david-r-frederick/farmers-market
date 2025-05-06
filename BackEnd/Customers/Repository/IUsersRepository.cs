namespace Customers.Repository;

using Core.Models;
using Customers.DataModel.Entities;
using Customers.DataModel.Models;

public interface IUsersRepository
{
    Task<FullUserModel?> GetByIdAsync(int id);

    Task<List<ListUserModel>> GetAllAsync(Paging paging);

    Task<int> AddAsync(FullUserModel model, string password);

    Task UpdateAsync(FullUserModel model);

    Task DeleteAsync(int id);
}
