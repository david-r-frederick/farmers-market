namespace Categories.Repository;

using Core;
using Categories.DataModel.Models;
using Categories.DataModel.Entities;

public class CategoriesRepository : Repository<Category, FullCategoryModel, ListCategoryModel>, ICategoriesRepository
{
}
