namespace Events.DataModel.Entities;

using Core.DataModel;
using Core.DataModel.Entities;

[SQLTable("Events", "EventVendor")]
public partial class EventVendor : BaseEntity
{
    public int EventId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public int VendorId { get; set; }

    public virtual Vendor Vendor { get; set; } = null!;
}
