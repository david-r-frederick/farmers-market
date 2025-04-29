namespace Categories.Repository;

using Core;
using Categories.DataModel.Models;
using Categories.DataModel.Entities;
using AutoMapper;

public class CategoriesRepository : Repository<Category, FullCategoryModel, ListCategoryModel>, ICategoriesRepository
{
    public CategoriesRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper) : base(dbFactory, mapper)
    {
    }
}
