namespace Core;

using Core.Models;

public interface IRepository<TFullModel, TListModel>
    where TFullModel : BaseModel
    where TListModel : BaseModel
{
    Task<TFullModel?> GetByIdAsync(int id);

    Task<PagedResult<TListModel>> GetAllAsync(Paging paging);

    Task<int> AddAsync(TFullModel model);

    Task UpdateAsync(TFullModel model);

    Task DeleteAsync(int id);
}
