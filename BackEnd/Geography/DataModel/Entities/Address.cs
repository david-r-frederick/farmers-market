namespace Geography.DataModel.Entities;

using Core.DataModel.Entities;

public partial class Address : BaseEntity
{
    public string Street1 { get; set; } = null!;

    public string Street2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string ZipCode { get; set; } = null!;
}
