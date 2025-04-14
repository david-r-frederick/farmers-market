namespace Products.Repository;

using Products.DataModel.Entities;
using Core;

public class ProductRepository : IProductRepository
{
    private readonly IDatabaseContext databaseContext;

    public ProductRepository(IDatabaseContext unitOfWork)
    {
        databaseContext = unitOfWork;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await databaseContext.Set<Product>().FindAsync(id);
    }

    public async Task AddAsync(Product product)
    {
        await databaseContext.Set<Product>().AddAsync(product);
        await databaseContext.SaveChangesAsync(new());
    }
}
