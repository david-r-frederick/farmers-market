namespace Products.Repository;

using Core;
using Products.DataModel.Models;

public interface IProductsRepository : IRepository<ProductModel>
{
    Task<List<ProductModel?>> GetMultipleByCategoryIDAsync(int categoryID);
}
