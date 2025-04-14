namespace Events.DataModel.Entities;

using Core.DataModel;
using Core.DataModel.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[SQLTable("Events", "Company")]
public partial class Company : BaseEntity
{
    public string Name { get; set; } = null!;

    public string? StartedDate { get; set; }
}
