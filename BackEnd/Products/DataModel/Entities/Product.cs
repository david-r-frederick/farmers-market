namespace Products.DataModel.Entities;

using Core;
using Core.Entities;

[SQLTable("Products", "Product")]
public partial class Product : BaseEntity
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Ingredients { get; set; }

    public string? Disclaimer { get; set; }

    public double? Price { get; set; }

    public string? Allergens { get; set; }

    public required int TypeId { get; set; }

    public virtual ProductType? Type { get; set; }

    public virtual ICollection<CategoryProduct> CategoryProducts { get; set; } = new HashSet<CategoryProduct>();
}
