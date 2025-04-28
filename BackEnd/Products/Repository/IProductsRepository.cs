namespace Products.Repository;

using Core;
using Products.DataModel.Models;

public interface IProductsRepository : IRepository<FullProductModel>
{
    Task<List<FullProductModel?>> GetMultipleByCategoryIDAsync(int categoryID);
}
