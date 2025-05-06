namespace Products.DataModel.Models;

using Core.DataModel.Models;
using Products.DataModel.Entities;

public partial class ListProductModel : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public string? Ingredients { get; set; }

    public decimal Price { get; set; }

    public int TypeId { get; set; }

    public ProductType? Type { get; set; }
}
