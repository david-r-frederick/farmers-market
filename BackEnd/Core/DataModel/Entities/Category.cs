namespace Core.DataModel.Entities;

public partial class Category : BaseEntity
{
    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }

    public virtual Category? Parent { get; set; }

    public virtual ICollection<Category> Children { get; set; } = new HashSet<Category>();

    //public virtual ICollection<CategoryProduct> Products { get; set; } = new HashSet<CategoryProduct>();
}
