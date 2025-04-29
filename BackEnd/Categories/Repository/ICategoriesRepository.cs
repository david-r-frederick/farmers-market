namespace Categories.Repository;

using Core;
using Categories.DataModel.Models;

public interface ICategoriesRepository : IRepository<FullCategoryModel, ListCategoryModel>
{
}
