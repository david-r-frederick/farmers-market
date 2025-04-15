namespace Products.Repository;

using Core;
using Products.DataModel.Entities;

public interface IProductsRepository : IRepository<Product>
{
    Task<List<Product?>> GetMultipleByCategoryIDAsync(int categoryID);
}
