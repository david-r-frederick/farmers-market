namespace Entities.Events;

using Entities.Core;

[SQLTable("Events", "Booth")]
public partial class Booth : BaseEntity
{
    public int EventId { get; set; }

    public Event? Event { get; set; }

    public int VendorId { get; set; }

    public Vendor? Vendor { get; set; }

    // String because it will not be used for calculations
    public string BoothNumber { get; set; } = null!;

    public bool ElectricityAvailable { get; set; }

    public bool IsInsidePavilion { get; set; }

    public int? X { get; set; }

    public int? Y { get; set; }
}
