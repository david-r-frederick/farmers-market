using Geography.DataModel.Models;

namespace Events.DataModel.Models;

public class EventForm
{
    public FullAddressModel Address { get; set; } = null!;

    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;
}
