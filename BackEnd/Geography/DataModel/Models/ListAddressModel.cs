namespace Geography.DataModel.Models;

using Core.Models;

public class ListAddressModel : BaseModel
{
    public string Street1 { get; set; } = null!;

    public string Street2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string ZipCode { get; set; } = null!;
}
