using Core.DataModel.Models;

namespace Categories.DataModel.Models;

public partial class FullCategoryModel : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public int? ParentId { get; set; }
}
