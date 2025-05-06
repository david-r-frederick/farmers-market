namespace Events.DataModel.Entities;

using Core;
using Core.DataModel.Entities;

[SQLTable("Events", "Company")]
public partial class Business : BaseEntity
{
    public string Name { get; set; } = null!;

    public string? StartedDate { get; set; }
}
