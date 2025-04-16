namespace Events.DataModel.Entities;

using Core;
using Core.Entities;

[SQLTable("Events", "Company")]
public partial class Company : BaseEntity
{
    public string Name { get; set; } = null!;

    public string? StartedDate { get; set; }
}
