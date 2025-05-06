using Core.DataModel.Models;

namespace Categories.DataModel.Models;

public partial class ListCategoryModel : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public int? ParentId { get; set; }
}
