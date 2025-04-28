namespace Products.Repository;

using Core;
using Products.DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Products.DataModel.Models;

public class ProductsRepository : Repository<ProductModel>, IProductsRepository
{
    private readonly IMapper _mapper;

    public ProductsRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper) : base(dbFactory)
    {
        _mapper = mapper;
    }

    public override async Task<ProductModel?> GetByIdAsync(int productId)
    {
        using var context = _dbFactory.GetContext();
        var product = await context.Set<Product>()
            .AsNoTracking()
            .Where(x => x.IsActive && x.Id == productId)
            .Include(x => x.CategoryProducts)
            .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);
        return _mapper.Map<ProductModel>(product);
    }

    public async Task<List<ProductModel?>> GetMultipleByCategoryIDAsync(int categoryID)
    {
        using var context = _dbFactory.GetContext();
        var products = await context.Set<CategoryProduct>()
            .Where(p => p.CategoryId == categoryID)
            .Select(x => x.Product)
            .ToListAsync();
        return products
            .Select(x => _mapper.Map<ProductModel?>(x))
            .ToList();
    }
}
