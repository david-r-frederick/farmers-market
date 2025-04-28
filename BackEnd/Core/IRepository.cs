namespace Core;

using Core.Models;

public interface IRepository<TModel> where TModel : BaseModel
{
    Task<TModel?> GetByIdAsync(int id);

    Task AddAsync(TModel entity);

    Task UpdateAsync(TModel entity);

    Task DeleteAsync(int id);
}
