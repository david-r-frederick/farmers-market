namespace Products.Repository;

using Products.DataModel.Entities;
using Core;
using Microsoft.EntityFrameworkCore;

public class ProductsRepository : Repository<Product>, IProductsRepository
{
    public ProductsRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
    {
    }

    public async Task<List<Product?>> GetMultipleByCategoryIDAsync(int categoryID)
    {
        return await _databaseContext.Set<CategoryProduct>()
            .Where(p => p.CategoryId == categoryID)
            .Select(x => x.Product)
            .ToListAsync();
    }
}
