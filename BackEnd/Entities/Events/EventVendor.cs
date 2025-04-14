namespace Entities.Events;

using Entities.Core;

[SQLTable("Events", "EventVendor")]
public partial class EventVendor : BaseEntity
{
    public int EventId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public int VendorId { get; set; }

    public virtual Vendor Vendor { get; set; } = null!;
}
