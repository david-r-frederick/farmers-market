namespace Entities.Events;

using Entities.Core;

[SQLTable("Events", "Company")]
public partial class Company : BaseEntity
{
    public string Name { get; set; } = null!;

    public string? StartedDate { get; set; }
}
