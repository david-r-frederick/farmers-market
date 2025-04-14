namespace Products.Repository;

using Products.DataModel.Entities;

public interface IProductsRepository
{
    Task<Product?> GetByIdAsync(int id);

    Task AddAsync(Product product);
}
