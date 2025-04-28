namespace Categories.Repository;

using Core;
using Categories.DataModel.Entities;

public class CategoriesRepository : Repository<Category>, ICategoriesRepository
{
    public CategoriesRepository(IDbContextFactoryWrapper dbFactory) : base(dbFactory)
    {
    }
}
