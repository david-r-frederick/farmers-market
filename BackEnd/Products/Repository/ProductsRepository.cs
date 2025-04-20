namespace Products.Repository;

using Core;
using Products.DataModel.Entities;
using Microsoft.EntityFrameworkCore;

public class ProductsRepository : Repository<Product>, IProductsRepository
{
    public ProductsRepository(IDbContextFactoryWrapper dbFactory) : base(dbFactory)
    {
    }

    public async Task<List<Product?>> GetMultipleByCategoryIDAsync(int categoryID)
    {
        using var context = _dbFactory.GetContext();
        return await context.Set<CategoryProduct>()
            .Where(p => p.CategoryId == categoryID)
            .Select(x => x.Product)
            .ToListAsync();
    }
}
