namespace Events.DataModel.Entities;

using Core;
using Core.Entities;
using Customers.DataModel.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[SQLTable("Events", "Vendor")]
public partial class Vendor : BaseEntity
{
    public int UserId { get; set; }

    public virtual User? User { get; set; }

    public bool SignedDisclosure { get; set; }

    [JsonIgnore]
    [ForeignKey("Company")]
    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public ICollection<Booth> Booths { get; set; } = new HashSet<Booth>();

    public virtual ICollection<EventVendor> EventVendors { get; set; } = new HashSet<EventVendor>();
}
