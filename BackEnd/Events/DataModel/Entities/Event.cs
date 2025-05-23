﻿namespace Events.DataModel.Entities;

using Core;
using Core.DataModel.Entities;
using Geography.DataModel.Entities;

[SQLTable("Events", "Event")]
public partial class Event : BaseEntity
{
    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public int HostUserId { get; set; }

    public required int AddressId { get; set; }

    public virtual Address? Address { get; set; } = null!;

    public virtual ICollection<EventVendor> EventVendors { get; set; } = new HashSet<EventVendor>();

    public virtual ICollection<Booth> Booths { get; set; } = new HashSet<Booth>();
}
