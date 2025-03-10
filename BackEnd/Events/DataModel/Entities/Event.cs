namespace Events.DataModel.Entities;

using Core.DataModel.Entities;
using Geography.DataModel.Entities;

public partial class Event : BaseEntity
{
    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public Address Address { get; set; } = null!;

    public virtual ICollection<Vendor> Vendors { get; set; } = new HashSet<Vendor>();

    public virtual ICollection<Booth> Booths { get; set; } = new HashSet<Booth>();
}
