namespace Products.Repository;

using Core;
using Products.DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Products.DataModel.Models;

public class ProductsRepository : Repository<Product, FullProductModel, ListProductModel>, IProductsRepository
{
    public ProductsRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper) : base(dbFactory, mapper)
    {
    }

    public override async Task<FullProductModel?> GetByIdAsync(int productId)
    {
        using var context = _dbFactory.GetContext();
        var product = await context.Set<Product>()
            .AsNoTracking()
            .Where(x => x.IsActive && !x.IsDeleted && x.Id == productId)
            .Include(x => x.CategoryProducts)
            .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync();
        if (product is null)
        {
            return null;
        }
        return _mapper.Map<FullProductModel>(product);
    }

    public override async Task<int> AddAsync(FullProductModel model)
    {
        using var context = _dbFactory.GetContext();
        var product = _mapper.Map<Product>(model);
        await context.Set<Product>().AddAsync(product);
        await context.SaveChangesAsync();

        if (model.Categories is not null && model.Categories.Count > 0)
        {
            foreach (var categoryModel in model.Categories)
            {
                var categoryProduct = new CategoryProduct
                {
                    ProductId = product.Id,
                    CategoryId = categoryModel.Id,
                    CreatedOn = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                };
                await context.Set<CategoryProduct>().AddAsync(categoryProduct);
            }
            await context.SaveChangesAsync();
        }
        return product.Id;
    }

    public async Task<List<FullProductModel?>> GetMultipleByCategoryIdAsync(int categoryId)
    {
        using var context = _dbFactory.GetContext();
        var products = await context.Set<Product>()
            .Where(x => !x.IsDeleted)
            .Where(x => context.Set<CategoryProduct>()
                .Where(y => !y.IsDeleted && y.CategoryId == categoryId)
                .Select(y => y.ProductId)
                .Contains(x.Id))
            .Include(x => x.CategoryProducts)
            .ThenInclude(x => x.Category)
            .Distinct()
            .ToListAsync();
        return products
            .Select(x => _mapper.Map<FullProductModel?>(x))
            .ToList();
    }
}
