using Core;
using Core.Entities;

namespace Categories.DataModel.Entities;

[SQLTable("Categories", "Category")]
public partial class Category : BaseEntity
{
    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }

    public virtual Category? Parent { get; set; }

    public virtual ICollection<Category> Children { get; set; } = new HashSet<Category>();
}
