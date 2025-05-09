﻿namespace Products.DataModel.Entities;

using Core;
using Core.DataModel.Entities;

[SQLTable("Products", "ProductType")]
public partial class ProductType : BaseEntity
{
    public string Name { get; set; } = null!;
}
