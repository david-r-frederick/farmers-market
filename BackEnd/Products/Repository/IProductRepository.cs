using Products.DataModel.Entities;

namespace Products.Repository;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);

    Task AddAsync(Product product);
}
