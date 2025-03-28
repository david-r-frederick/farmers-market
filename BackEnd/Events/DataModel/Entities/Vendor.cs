﻿namespace Events.DataModel.Entities;

using Core.DataModel.Entities;
using System.Text.Json.Serialization;
using Users.DataModel.Entities;

public partial class Vendor : BaseEntity
{
    public int UserId { get; set; }

    public virtual User? User { get; set; }

    public bool SignedDisclosure { get; set; }

    [JsonIgnore]
    public int? CompanyID { get; set; }

    public ICollection<Booth> Booths { get; set; } = new HashSet<Booth>();
}
