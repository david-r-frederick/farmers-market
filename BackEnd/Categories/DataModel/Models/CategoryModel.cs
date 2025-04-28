using Core.Models;

namespace Categories.DataModel.Models;

public partial class CategoryModel : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public int? ParentId { get; set; }
}
