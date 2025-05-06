namespace Products.DataModel.Entities;

using Core;
using Core.DataModel.Entities;
using Categories.DataModel.Entities;

[SQLTable("Products", "CategoryProduct")]
public partial class CategoryProduct : BaseEntity
{
    public int CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public int ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
