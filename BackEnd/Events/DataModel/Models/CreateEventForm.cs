using Geography.DataModel.Models;

namespace Events.DataModel.Models;

public class CreateEventForm
{
    public FullAddressModel Address { get; set; } = null!;

    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;
}
