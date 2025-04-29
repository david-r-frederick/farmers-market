namespace Products.Repository;

using Core;
using Products.DataModel.Models;

public interface IProductsRepository : IRepository<FullProductModel, ListProductModel>
{
    Task<List<FullProductModel?>> GetMultipleByCategoryIdAsync(int categoryId);
}
