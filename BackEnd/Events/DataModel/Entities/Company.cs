namespace Events.DataModel.Entities;

using Core.DataModel.Entities;

public partial class Company : BaseEntity
{
    public string Name { get; set; } = null!;

    public string? StartedDate { get; set; }

    public virtual Vendor? Vendor { get; set; }

    public int? VendorID { get; set; }
}
