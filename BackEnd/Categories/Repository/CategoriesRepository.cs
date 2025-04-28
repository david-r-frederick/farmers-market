namespace Categories.Repository;

using Core;
using Categories.DataModel.Models;

public class CategoriesRepository : Repository<CategoryModel>, ICategoriesRepository
{
    public CategoriesRepository(IDbContextFactoryWrapper dbFactory) : base(dbFactory)
    {
    }
}
