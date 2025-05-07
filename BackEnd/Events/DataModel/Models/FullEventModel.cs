namespace Events.DataModel.Models;

using Core.DataModel.Models;
using Geography.DataModel.Models;

public class FullEventModel : BaseModel
{
    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public int HostUserId { get; set; }

    public int AddressId { get; set; }

    public FullAddressModel Address { get; set; } = null!;
}
