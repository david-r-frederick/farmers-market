﻿namespace Products.DataModel.Models;

using Categories.DataModel.Models;
using Core.DataModel.Models;
using Products.DataModel.Entities;

public partial class FullProductModel : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Ingredients { get; set; }

    public string? Disclaimer { get; set; }

    public string? Allergens { get; set; }

    public decimal Price { get; set; }

    public int TypeId { get; set; }

    public ProductType? Type { get; set; }

    public List<FullCategoryModel>? Categories { get; set; }
}
