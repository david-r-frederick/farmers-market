namespace Categories.Repository;

using Core;
using Categories.DataModel.Models;
using Categories.DataModel.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;

public class CategoriesRepository : Repository<Category, FullCategoryModel, ListCategoryModel>, ICategoriesRepository
{
    public CategoriesRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(dbFactory, mapper, httpContextAccessor)
    {
    }
}
