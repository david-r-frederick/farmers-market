﻿namespace Geography.DataModel.Models;

using Core.DataModel.Models;

public class FullAddressModel : BaseModel
{
    public string Street1 { get; set; } = null!;

    public string Street2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string ZipCode { get; set; } = null!;
}
